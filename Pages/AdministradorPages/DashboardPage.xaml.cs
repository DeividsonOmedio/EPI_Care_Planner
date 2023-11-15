using Epi_Care_Planner.Context;

namespace Epi_Care_Planner.Pages.AdministradorPages;

public partial class DashboardPage : ContentPage
{
	AppDbContext _context = new AppDbContext();
	public DashboardPage()
	{
		InitializeComponent();
		CarregarLista();
        // Adicione o evento de refresh ao RefreshView
        refreshView.Refreshing += (sender, e) =>
        {
            // Lógica de recarregamento
            CarregarLista();

            // Após a conclusão da operação de recarregamento, pare o indicador de refresh
            refreshView.IsRefreshing = false;
        };
    }
		public void CarregarLista()
	{
		var lista = _context.emprestimos.Where(x => x.Status.ToLower() == "emprestado").ToList();
		if (lista.Count == 0)
		{
			lblnaoemp.IsVisible = true;
            gridHeader.IsVisible = false;

        }
		else
		{
            lblnaoemp.IsVisible = false;
            ListaEpisBanco.ItemsSource = lista;
		}
	}
}