using Epi_Care_Planner.Context;

namespace Epi_Care_Planner.Pages.Modal;

public partial class ModalEmprestar : ContentPage
{
    AppDbContext _context = new AppDbContext();
    int IdEmpretimo = 0;
    public ModalEmprestar(int idEmprestimo)
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
            result.Status = "Emprestado";
            result.DataEmpretimo = Convert.ToString(DateTime.Now);
            result.ComentarioAlmoxarife = comentarioFeito;
            var resultEpi = _context.epis.FirstOrDefault(x => x.Nome == result.Epi);
            resultEpi.QuantidadeAtual--;
            _context.epis.Update(resultEpi);
            _context.emprestimos.Update(result);
            _context.SaveChanges();
            DisplayAlert("Sucesso", "Emprestimo Confirmado", "Fechar");
            Navigation.PopModalAsync();

        }
        catch
        {
            DisplayAlert("Atenção", "Erro ao atualizar solicitação", "Fechar");
            return;
        }
    }
    private void FecharModal_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}