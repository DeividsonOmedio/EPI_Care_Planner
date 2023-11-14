using Epi_Care_Planner.Context;
using Epi_Care_Planner.Model;
using Epi_Care_Planner.Pages.Modal;

namespace Epi_Care_Planner.Pages.FuncionarioPages;

public partial class ListaEpiPage : ContentPage
{
    private AppDbContext _context = new AppDbContext();
    Usuario usuarioLogado = new Usuario();
    public ListaEpiPage(Usuario user)
	{
		InitializeComponent();
        CarregarPicker();
        usuarioLogado = user;
    }
    public void CarregarPicker()
    {
        List<Epi> listaEpi = _context.epis.ToList();
        ListaEpisBanco.ItemsSource = listaEpi;
    }
  

    private void detalhesSwipe_Invoked(object sender, EventArgs e)
    {
        SwipeItem swipeItem = (SwipeItem)sender;
        Epi item = (Epi)swipeItem.BindingContext;
        Navigation.PushModalAsync(new ModalEpiFuncionario(usuarioLogado, item));
    }
}