using Epi_Care_Planner.Context;
using Epi_Care_Planner.Model;
using System.Windows.Input;

namespace Epi_Care_Planner.Pages.FuncionarioPages;

public partial class DashboardPage : ContentPage
{
    AppDbContext _context = new AppDbContext();
    public Usuario UsuarioLogado { get; set; }
    public ICommand CarregarSolicitacoesComand { get; set; }

    public DashboardPage(Usuario usuarioLogado)
    {
        UsuarioLogado = usuarioLogado;
        InitializeComponent();
        // Adicione o evento de refresh ao RefreshView
        refreshView.Refreshing += (sender, e) =>
        {
            // Lógica de recarregamento
            CarregarSolicitacoes();
            CarregarEmprestados();

            // Após a conclusão da operação de recarregamento, pare o indicador de refresh
            refreshView.IsRefreshing = false;
        };
        CarregarSolicitacoes();
        CarregarEmprestados();
        CarregarSolicitacoesComand = new Command(() =>
        {
            CarregarSolicitacoes();
            CarregarEmprestados();
        });
    }


    
    public void CarregarEmprestados()
    {
        var lista = _context.emprestimos.Where(x => x.Status.ToLower() == "emprestado" && x.Funcionario == UsuarioLogado.Name).ToList();
        if (lista.Count == 0)
        {
            lblnaoEmp.IsVisible = true;
            gridEmp.IsVisible = false;
        }
        ListaEpisEmprestado.ItemsSource = lista;
    }

    public void CarregarSolicitacoes()
    {
        var lista = _context.emprestimos.Where(x => x.Status.ToLower() == "pendente" || x.Status.ToLower() == "confirmado" || x.Status.ToLower() == "recusado" && x.Funcionario == UsuarioLogado.Name).ToList();
        if (lista.Count == 0)
        {
            lblnaosolic.IsVisible = true;
            gridSolic.IsVisible = false;
        }
        ListaSolicitacaoEpis.ItemsSource = lista;
    }
}