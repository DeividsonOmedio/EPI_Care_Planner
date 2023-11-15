using Epi_Care_Planner.Context;
using Epi_Care_Planner.Model;
using Epi_Care_Planner.Pages.Modal;

namespace Epi_Care_Planner.Pages.AlmoxarifePages;

public partial class DashboardPage : ContentPage
{
    AppDbContext _context = new AppDbContext();
	public DashboardPage()
	{
		InitializeComponent();
        CarregarSolicitacoes();

        // Adicione o evento de refresh ao RefreshView
        refreshView.Refreshing += (sender, e) =>
        {
            // L�gica de recarregamento
            CarregarSolicitacoes();

            // Ap�s a conclus�o da opera��o de recarregamento, pare o indicador de refresh
            refreshView.IsRefreshing = false;
        };
    }

    public void CarregarSolicitacoes()
    {
        var lista = _context.emprestimos.Where(x => x.Status.ToLower() == "pendente").ToList();
        if(lista.Count == 0)
        {
            lblnaoemp.IsVisible = true;
            gridsolicitacoes.IsVisible = false;
            
        }
        ListaSolicitacoes.ItemsSource = lista;

        var listaConfirmada = _context.emprestimos.Where(x => x.Status.ToLower() == "confirmado").ToList();
        if (listaConfirmada.Count == 0)
        {
            lblnaoconfir.IsVisible = true;
            gridConfirm.IsVisible = false;
        }
        else
        {
            lblnaoconfir.IsVisible = false;
            ListaConfirmadas.ItemsSource = listaConfirmada;

        }

    }

    

    private void SwipeItem_Invoked_Confirmar(object sender, EventArgs e)
    {
        // Obt�m o SwipeItem clicado
        SwipeItem swipeItem = (SwipeItem)sender;

        // Obt�m o item associado ao SwipeItem
        Emprestimo item = (Emprestimo)swipeItem.BindingContext;

        // Agora voc� pode acessar o ID ou qualquer outra propriedade do item
        int idDoItem = item.Id; // Substitua "Id" pelo nome da propriedade que cont�m o ID

        Navigation.PushModalAsync(new ModalComentarioConfirmar(idDoItem));
        Navigation.PushAsync(new AlmoxarifePage());

    }

    private void SwipeItem_Invoked_Recusar(object sender, EventArgs e)
    {
        SwipeItem swipeItem = (SwipeItem)sender;

        Emprestimo item = (Emprestimo)swipeItem.BindingContext;

        int idDoItem = item.Id; 

        Navigation.PushModalAsync(new ModalComentarioRecusar(idDoItem));
        CarregarSolicitacoes();
    }
    private void SwipeItem_Invoked_Emprestado(object sender, EventArgs e)
    {
        SwipeItem swipeItem = (SwipeItem)sender;

        Emprestimo item = (Emprestimo)swipeItem.BindingContext;

        int idDoItem = item.Id; 

        Navigation.PushModalAsync(new ModalEmprestar(idDoItem));
        CarregarSolicitacoes();
    }

    private void SwipeItem_Invoked_Cancelado(object sender, EventArgs e)
    {
        SwipeItem swipeItem = (SwipeItem)sender;

        Emprestimo item = (Emprestimo)swipeItem.BindingContext;

        int idDoItem = item.Id; 

        Navigation.PushModalAsync(new ModalCancelar(idDoItem));
        CarregarSolicitacoes();
    }
}