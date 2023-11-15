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
        lblnaoemp.IsVisible = false;

        var listaConfirmada = _context.emprestimos.Where(x => x.Status.ToLower() == "confirmado").ToList();
        if (listaConfirmada.Count == 0)
        {
            lblnaoemp.IsVisible = true;
            gridConfirm.IsVisible = false;
        }
        ListaConfirmadas.ItemsSource = listaConfirmada;

    }

    

    private void SwipeItem_Invoked_Confirmar(object sender, EventArgs e)
    {
        // Obtém o SwipeItem clicado
        SwipeItem swipeItem = (SwipeItem)sender;

        // Obtém o item associado ao SwipeItem
        Emprestimo item = (Emprestimo)swipeItem.BindingContext;

        // Agora você pode acessar o ID ou qualquer outra propriedade do item
        int idDoItem = item.Id; // Substitua "Id" pelo nome da propriedade que contém o ID

        Navigation.PushModalAsync(new ModalComentarioConfirmar(idDoItem));
        CarregarSolicitacoes();

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