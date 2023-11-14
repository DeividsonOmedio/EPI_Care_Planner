using Epi_Care_Planner.Context;

namespace Epi_Care_Planner.Pages.Modal;

public partial class ModalComentarioRecusar : ContentPage
{
    AppDbContext _context = new AppDbContext();
    int IdEmpretimo = 0;
    public ModalComentarioRecusar(int idEmprestimo)
    {
        IdEmpretimo = idEmprestimo;
        InitializeComponent();
	}

    private void btnRecusar_Clicked(object sender, EventArgs e)
    {

        var comentarioFeito = txtComentario.Text;
        try
        {
            var result = _context.emprestimos.FirstOrDefault(x => x.Id == IdEmpretimo);
            result.Status = "Recusado";
            result.ComentarioAlmoxarife = comentarioFeito;
            _context.emprestimos.Update(result);
            _context.SaveChanges();
            DisplayAlert("", "Solicitação Recusada", "Fechar");
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