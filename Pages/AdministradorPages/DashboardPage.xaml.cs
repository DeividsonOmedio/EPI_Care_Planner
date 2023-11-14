using Epi_Care_Planner.Context;

namespace Epi_Care_Planner.Pages.AdministradorPages;

public partial class DashboardPage : ContentPage
{
	AppDbContext _context = new AppDbContext();
	public DashboardPage()
	{
		InitializeComponent();
		CarregarLista();
	}
		public void CarregarLista()
	{
		var lista = _context.emprestimos.Where(x => x.Status.ToLower() == "emprestado").ToList();
		if (lista[0].Epi == "")
		{
			lblnaoemp.IsVisible = true;
		}
		else
		{
            lblnaoemp.IsVisible = false;
            ListaEpisBanco.ItemsSource = lista;
		}
	}
}