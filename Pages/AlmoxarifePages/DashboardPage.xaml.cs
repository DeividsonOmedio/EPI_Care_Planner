using Epi_Care_Planner.Context;

namespace Epi_Care_Planner.Pages.AlmoxarifePages;

public partial class DashboardPage : ContentPage
{
    AppDbContext _context = new AppDbContext();
	public DashboardPage()
	{
		InitializeComponent();
        CarregarSolicitacoes();
	}

    public void CarregarSolicitacoes()
    {
        var lista = _context.emprestimos.Where(x => x.Status.ToLower() == "pendente").ToList();
        if(lista == null)
        {
            DisplayAlert("Resposta", "Não ha novas solicitações no momento", "Fechar");
            return;
        }
        ListaSolicitacoes.ItemsSource = lista;
        

    }

    private void CorfimarEprestimo_Clicked(object sender, EventArgs e)
    {

    }

    private void RecusarEprestimo_Clicked(object sender, EventArgs e)
    {

    }
}