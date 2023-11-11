using Epi_Care_Planner.Model;
using Epi_Care_Planner.Pages.FuncionarioPages;

namespace Epi_Care_Planner.Pages;

public partial class FuncionarioPage : TabbedPage
{
    public FuncionarioPage(Usuario usuarioLogado)
    {
        InitializeComponent();

        var pagina1 = new DashboardPage()
        {
            Title = "Dashboard",
            IconImageSource = ""
        };

        var pagina2 = new SolicitacaoPage(usuarioLogado)
        {
            Title = "Solicitacao",
            IconImageSource = ""
        };
        var pagina3 = new ListaEpiPage()
        {
            Title = "Lista Epi's",
            IconImageSource = ""
        };

        this.Children.Add(pagina1);
        this.Children.Add(pagina2);
        this.Children.Add(pagina3);
    }
}