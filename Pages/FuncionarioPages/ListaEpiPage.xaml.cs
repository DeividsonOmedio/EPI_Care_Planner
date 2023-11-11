using Epi_Care_Planner.Context;
using Epi_Care_Planner.Model;

namespace Epi_Care_Planner.Pages.FuncionarioPages;

public partial class ListaEpiPage : ContentPage
{
    private AppDbContext _context = new AppDbContext();
    public ListaEpiPage()
	{
		InitializeComponent();
        CarregarPicker();
    }
    public void CarregarPicker()
    {
        List<Epi> listaEpi = _context.epis.ToList();
        ListaEpisBanco.ItemsSource = listaEpi;
    }
    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}