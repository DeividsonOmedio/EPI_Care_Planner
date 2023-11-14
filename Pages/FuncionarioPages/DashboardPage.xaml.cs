using Epi_Care_Planner.Context;
using Epi_Care_Planner.Model;

namespace Epi_Care_Planner.Pages.FuncionarioPages;

public partial class DashboardPage : ContentPage
{
    AppDbContext _context = new AppDbContext();
    public Usuario UsuarioLogado { get; set; }

    public DashboardPage(Usuario usuarioLogado)
    {
        UsuarioLogado = usuarioLogado;
        InitializeComponent();
        CarregarSolicitacoes();
        CarregarEmprestados();
    }

    public void CarregarEmprestados()
    {
        var lista = _context.emprestimos.Where(x => x.Status.ToLower() == "emprestado" && x.Funcionario == UsuarioLogado.Name).ToList();
        if (lista == null)
        {
            DisplayAlert("Resposta", "Não ha novas solicitações no momento", "Fechar");
            return;
        }
        ListaEpisEmprestado.ItemsSource = lista;
    }

    public void CarregarSolicitacoes()
    {
        var lista = _context.emprestimos.Where(x => x.Status.ToLower() == "pendente" || x.Status.ToLower() == "confirmado" || x.Status.ToLower() == "recusado" && x.Funcionario == UsuarioLogado.Name).ToList();
        if (lista == null)
        {
            DisplayAlert("Resposta", "Não ha novas solicitações no momento", "Fechar");
            return;
        }
        ListaSolicitacaoEpis.ItemsSource = lista;
    }
}