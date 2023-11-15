using Epi_Care_Planner.Context;
using Epi_Care_Planner.Model;
using Epi_Care_Planner.Pages;
using Epi_Care_Planner.Services;
using Microsoft.EntityFrameworkCore;

namespace Epi_Care_Planner.Pages.FuncionarioPages;

public partial class SolicitacaoPage : ContentPage
{
    string picker = "";
    string funcaoCaptada = "";
    public Usuario UsuarioLogado { get; set; }

    private AppDbContext _context = new AppDbContext();
    public SolicitacaoPage(Usuario usuarioLogado)
	{
        UsuarioLogado = usuarioLogado;
        
		InitializeComponent();
        carregarPicker();
	}
    public void carregarPicker()
    { 
        List<string> lista = new List<string>();
        var listaEpi = _context.epis.ToList();
        listaEpi.ForEach(listaEpi => { lista.Add(listaEpi.Nome); });

        pickerEpi.ItemsSource = listaEpi;
    }
    private void pickerEpi_SelectedIndexChanged(object sender, EventArgs e)
    {
        var pic = (Picker)sender;
        int selectedIndex = pic.SelectedIndex;
        if (selectedIndex != -1)
        {
            funcaoCaptada = pic.Items[selectedIndex];
             
            
        }
        
    }

    private void pickerQuando_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        var pic = (Picker)sender;
        int selectedIndex = pic.SelectedIndex;
        if (selectedIndex != -1)
        {
            picker = pic.Items[selectedIndex];
        }
        if (picker == "Agendar")
            txtAgendar.IsVisible = true;
        else
        {
            txtAgendar.IsVisible = false;
        }
            
    }
    
    private void btnSolicitarEmprestimo_Clicked(object sender, EventArgs e)
    {
        if(string.IsNullOrEmpty(funcaoCaptada) || string.IsNullOrEmpty(picker))
        {
            DisplayAlert("Aten��o", "Selecione um EPI e Para Quando � o emprestimo", "Fechar");
            return;
        }
        if (picker == "Agendar")
            picker = txtAgendar.Text;
        Emprestimo novoEmprestimo = new Emprestimo();
        novoEmprestimo.Epi = funcaoCaptada;
        novoEmprestimo.Funcionario = UsuarioLogado.Name;
        novoEmprestimo.DataPrevisaoEmprestimo = picker;
        novoEmprestimo.DataPrevisaoDevolucao = "";
        novoEmprestimo.DataEmpretimo = "";
        novoEmprestimo.Status = "pendente";
        novoEmprestimo.ComentarioFuncionario = txtcomentario.Text;
        novoEmprestimo.DataSolicitacao = Convert.ToString(DateTime.Now);
        novoEmprestimo.ComentarioAlmoxarife = "";

        try
        {
        _context.emprestimos.Add(novoEmprestimo);
        _context.SaveChanges();
            picker = "";
            pickerEpi.SelectedItem = null;
            pickerQuando.SelectedItem = null;
            funcaoCaptada = "";
            txtAgendar.Text = "";
            txtAgendar.IsVisible = false;
            txtcomentario.Text = "";
            DisplayAlert("Sucesso", "Emprestimo Solicitado", "Fechar");
            return;
        }
        catch(Exception)
        { 
            DisplayAlert("Aten��o", "Falha ao soicitar Emprestimo ", "Fechar");
            Navigation.PushModalAsync(new SolicitacaoPage(UsuarioLogado));
            Navigation.PushAsync(new FuncionarioPage(UsuarioLogado));
        }
    }

}