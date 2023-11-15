using Epi_Care_Planner.Context;
using Epi_Care_Planner.Model;

namespace Epi_Care_Planner.Pages.Modal;

public partial class ModalComentarioConfirmar : ContentPage
{
    AppDbContext _context = new AppDbContext();
    int IdEmpretimo = 0;
	public ModalComentarioConfirmar(int idEmprestimo)
	{
        IdEmpretimo = idEmprestimo;
		InitializeComponent();
	}

    private void btnConfirmar_Clicked(object sender, EventArgs e)
    {
        var comentarioFeito = txtComentario.Text;
        try
        {
            var result = _context.emprestimos.FirstOrDefault(x => x.Id == IdEmpretimo);
            result.Status = "Confirmado";
            result.ComentarioAlmoxarife = comentarioFeito;
            _context.emprestimos.Update(result);
            _context.SaveChanges();
            DisplayAlert("Sucesso", "Solicitação Confirmada", "Fechar");
            Navigation.PopModalAsync();

        }
        catch
        {
            DisplayAlert("Atenção", "Erro ao Recusar solicitação", "Fechar");
            return;
        }
    }
    private void FecharModal_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}