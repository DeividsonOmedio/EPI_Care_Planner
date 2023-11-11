using Epi_Care_Planner.Context;
using Epi_Care_Planner.Model;
using System.Net.Mail;

namespace Epi_Care_Planner.Pages.AdministradorPages;

public partial class FuncionariosPage : ContentPage
{
    private AppDbContext _context = new AppDbContext();
    string funcaoCaptada = "";
    public FuncionariosPage()
	{
		InitializeComponent();
        
    }
    private void btnRegistrarFuncionarioNovo_Clicked(object sender, EventArgs e)
    {
        var matricula = txtMatriculaFuncionarioNovo.Text;
        var nome = txtNomeFuncionarioNovo.Text;
        var funcao = funcaoCaptada;
        var senha = txtSenhaFuncionarioNovo.Text;

        if (string.IsNullOrEmpty(matricula) || string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(funcao) || string.IsNullOrEmpty(senha))
        {
            DisplayAlert("Atencao", "Todos os campos devem ser preenchidos", "Fechar");
            return;
        }
        else
        {
            if (funcaoCaptada == "Funcionario Geral")
                funcaoCaptada = "Funcionario";
            Usuario novoUsuario = new Usuario();
            novoUsuario.Codigo = matricula;
            novoUsuario.Name = nome;
            novoUsuario.Funcao = funcaoCaptada;
            novoUsuario.Senha = senha;

            try
            {
            _context.users.Add(novoUsuario);
            _context.SaveChanges();
                DisplayAlert("Sucesso", "Funcionario Resgistrado com sucesso", "Fechar");
                Navigation.PushAsync(new AdministradorPages.FuncionariosPage());
            }
            catch 
            {
                
                DisplayAlert("Atencao", "Não foi possivel Resgistrar funcionario", "Fechar");
                return;
            }

        }
    }

    private void btnListar_Func_Clicked(object sender, EventArgs e)
    {
        btnAddFunc.IsVisible = false;
        btnListarFunc.IsVisible = false;
        tagListarFuncionarios.IsVisible = true;
        btnCancelarBusca.IsVisible = true;

        List<Usuario> listaUsuario = _context.users.ToList();
        ListaDosFunc.ItemsSource = listaUsuario;

    }

    private void btnAddAlm_Clicked(object sender, EventArgs e)
    {

    }

    private void btnAddFunc_Clicked(object sender, EventArgs e)
    {
        btnAddFunc.IsVisible = false;
        tagAddFunc.IsVisible = true;
        btnListarFunc.IsVisible = false;
        btnCancelarBusca.IsVisible = true;

        
    }

    private void btnCancelarBusca_Clicked(object sender, EventArgs e)
    {
        btnAddFunc.IsVisible = true;
        tagAddFunc.IsVisible = false;
        btnListarFunc.IsVisible = true;
        tagListarFuncionarios.IsVisible = false;
        btnCancelarBusca.IsVisible = false;

    }

    private void pickerFuncao_SelectedIndexChanged(object sender, EventArgs e)
    {
        var pic = (Picker)sender;
        int selectedIndex = pic.SelectedIndex;
        if (selectedIndex != -1)
        {
            funcaoCaptada = pic.Items[selectedIndex];
        }
    }
}