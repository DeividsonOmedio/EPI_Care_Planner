using Epi_Care_Planner.Pages.AdministradorPages;

namespace Epi_Care_Planner.Pages;

public partial class AdministradorPage : TabbedPage
{
    public AdministradorPage()
    {
        InitializeComponent();

        var pagina1 = new DashboardPage()
        {
            Title = "Dashboard",
            IconImageSource = ""
        };

        var pagina2 = new EpiPage()
        {
            Title = "Epi",
            IconImageSource = ""
        };
        var pagina3 = new FuncionariosPage()
        {
            Title = "Funcionarios",
            IconImageSource = ""
        };

        this.Children.Add(pagina1);
        this.Children.Add(pagina2);
        this.Children.Add(pagina3);
    }
}