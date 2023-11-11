using Epi_Care_Planner.Context;
using Epi_Care_Planner.Model;
using Epi_Care_Planner.Pages;
using Epi_Care_Planner.Services;
using Microsoft.EntityFrameworkCore;

namespace Epi_Care_Planner.Pages.FuncionarioPages;

public partial class SolicitacaoPage : ContentPage
{
    string picker = "Agora";
    Epi epiId = new Epi();
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
      
        pickerEpi.ItemsSource = lista.ToList();
        pickerEpi.ItemDisplayBinding = new Binding("Epi");
    }
    private void pickerEpi_SelectedIndexChanged(object sender, EventArgs e)
    {
        var pic = (Picker)sender;
        int selectedIndex = pic.SelectedIndex;
        if (selectedIndex != -1)
        {
            var nome = pic.Items[selectedIndex];
            epiId = _context.epis.FirstOrDefault(x => x.Nome == nome);
            
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
    }

    private void btnSolicitarEmprestimo_Clicked(object sender, EventArgs e)
    {
        Emprestimo novoEmprestimo = new Emprestimo();
        novoEmprestimo.EpiId = epiId;
        novoEmprestimo.FuncionarioId = UsuarioLogado;
        novoEmprestimo.DataPrevisaoEmprestimo = picker;
        novoEmprestimo.DataPrevisaoDevolucao = "";
        novoEmprestimo.DataEmpretimo = "";
        novoEmprestimo.Status = "pendente";
        novoEmprestimo.ComentarioFuncionario = txtcomentario.Text;

        try
        {
        _context.emprestimos.Add(novoEmprestimo);
        _context.SaveChanges();
            DisplayAlert("Sucesso", "Emprestimo Solicitado", "Fechar");
            return;
        }
        catch
        {
            DisplayAlert("Atenção", "Falha ao soicitar Emprestimo", "Fechar");
            return;
        }
    }

}