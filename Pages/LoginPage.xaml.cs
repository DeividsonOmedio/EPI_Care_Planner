using Epi_Care_Planner.Context;
using Epi_Care_Planner.Model;
using Epi_Care_Planner.Pages.FuncionarioPages;
using Epi_Care_Planner.Services.Intrefaces;

namespace Epi_Care_Planner.Pages;

public partial class LoginPage : ContentPage
{
    private AppDbContext _context = new AppDbContext();
    public LoginPage()
    {
        InitializeComponent();
        try
        {

            using (var db = new AppDbContext())
            {
                var items = db.users.FirstOrDefault(x => x.Name == "Admin");
                if (items == null)
                {
                    Usuario userAdmin = new Usuario();
                    userAdmin.Name = "Admin";
                    userAdmin.Senha = "admin123";
                    userAdmin.Codigo = "123";
                    userAdmin.Funcao = "admin";

                    db.users.Add(userAdmin);
                    db.SaveChanges();
                }



            }

        }
        catch
        {
            return;
        }
    }

    private async void btnEntrar_Clicked(object sender, EventArgs e)
    {
        string user = txtUser.Text;
        string senha = txtSenha.Text;

        if (!string.IsNullOrWhiteSpace(user) && !string.IsNullOrWhiteSpace(senha))
        {
            
                var response = _context.users.FirstOrDefault(x => x.Name == user && x.Senha == senha);
            if (response == null)
                {
                    await DisplayAlert("Atencao", "Email ou Senha Invalido", "Fechar");
                    return;
                }
                else if(response.Funcao.ToLower() == "admin")
                {
                    await Navigation.PushAsync(new AdministradorPage());
                }
                else if (response.Funcao.ToLower() == "almoxarife")
                {
                    await Navigation.PushAsync(new AlmoxarifePage());
                }
                else if (response.Funcao.ToLower() == "funcionario")
                {
                    await Navigation.PushAsync(new FuncionarioPage(response));
                }
            return;
        }
        }


    private void btnEntrarAdm_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AdministradorPage());
    }



    private void btnEntrarAlm_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AlmoxarifePage());
    }

    private void btnEntrar_Func_Clicked(object sender, EventArgs e)
    {
        
    }

}

