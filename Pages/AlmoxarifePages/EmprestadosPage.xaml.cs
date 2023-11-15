using Epi_Care_Planner.Context;
using Epi_Care_Planner.Model;

namespace Epi_Care_Planner.Pages.AlmoxarifePages;

public partial class EmprestadosPage : ContentPage
{
    AppDbContext _context = new AppDbContext();
    public EmprestadosPage()
	{
		InitializeComponent();
		CarregarEmprestados();

        // Adicione o evento de refresh ao RefreshView
        refreshView.Refreshing += (sender, e) =>
        {
            // L�gica de recarregamento
            CarregarEmprestados();

            // Ap�s a conclus�o da opera��o de recarregamento, pare o indicador de refresh
            refreshView.IsRefreshing = false;
        };
    }
	public void CarregarEmprestados()
	{
        var lista = _context.emprestimos.Where(x => x.Status.ToLower() == "emprestado").ToList();
        if (lista.Count == 0)
        {
            lblnaoEmp.IsVisible = true;
            gridEmp.IsVisible = false;
        }
        else
        {
        ListaEpisEmprestados.ItemsSource = lista;
        }
    }

    private void swpDevolucao_Invoked(object sender, EventArgs e)
    {
        SwipeItem swipeItem = (SwipeItem)sender;
        Emprestimo item = (Emprestimo)swipeItem.BindingContext;
        item.DataDevolucao = DateTime.Now.ToString();
        var resultEpi = _context.epis.FirstOrDefault(x => x.Nome == item.Epi);
        resultEpi.QuantidadeAtual++;

        _context.emprestimos.Update(item);
        _context.epis.Update(resultEpi);
        _context.SaveChanges();
        DisplayAlert("Sucesso", "Devolu��o Confirmada", "Fechar");
        (Application.Current.MainPage as NavigationPage)?.Navigation?.PopToRootAsync();
    }
}