using Epi_Care_Planner.Context;
using Epi_Care_Planner.Model;
using Epi_Care_Planner.Pages;
using Epi_Care_Planner.Services;
using Epi_Care_Planner.Services.Intrefaces;

namespace Epi_Care_Planner
{
    public partial class App : Application
    {

        static UsuarioService _bancoDados;

        public static UsuarioService BancoDados
        {
            get
            {
                if (_bancoDados == null)
                {
                    try
                    {
                        _bancoDados = new UsuarioService();

                    }
                    catch
                    {

                    }

                }
                return _bancoDados;
            }

        }
        public static Usuario Usuario { get; set; }
        public App()
        {
            InitializeComponent();

        
            using (var db = new AppDbContext())
            {
                db.Database.EnsureCreated();
            }
            MainPage = new NavigationPage(new LoginPage());
        }
    }
}