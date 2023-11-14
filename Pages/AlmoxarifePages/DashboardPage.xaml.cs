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
        if(lista == null)
        {
            DisplayAlert("Resposta", "Não ha novas solicitações no momento", "Fechar");
            return;
        }
        ListaSolicitacoes.ItemsSource = lista;

        var listaConfirmada = _context.emprestimos.Where(x => x.Status.ToLower() == "confirmado").ToList();
        if (lista == null)
        {
            DisplayAlert("Resposta", "Não ha novas solicitações no momento", "Fechar");
            return;
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
    }

    private void SwipeItem_Invoked_Recusar(object sender, EventArgs e)
    {
        // Obtém o SwipeItem clicado
        SwipeItem swipeItem = (SwipeItem)sender;

        // Obtém o item associado ao SwipeItem
        Emprestimo item = (Emprestimo)swipeItem.BindingContext;

        // Agora você pode acessar o ID ou qualquer outra propriedade do item
        int idDoItem = item.Id; // Substitua "Id" pelo nome da propriedade que contém o ID

        Navigation.PushModalAsync(new ModalComentarioRecusar(idDoItem));
    }
    private void SwipeItem_Invoked_Emprestado(object sender, EventArgs e)
    {
        // Obtém o SwipeItem clicado
        SwipeItem swipeItem = (SwipeItem)sender;

        // Obtém o item associado ao SwipeItem
        Emprestimo item = (Emprestimo)swipeItem.BindingContext;

        // Agora você pode acessar o ID ou qualquer outra propriedade do item
        int idDoItem = item.Id; // Substitua "Id" pelo nome da propriedade que contém o ID

        Navigation.PushModalAsync(new ModalEmprestar(idDoItem));
    }

    private void SwipeItem_Invoked_Cancelado(object sender, EventArgs e)
    {
        // Obtém o SwipeItem clicado
        SwipeItem swipeItem = (SwipeItem)sender;

        // Obtém o item associado ao SwipeItem
        Emprestimo item = (Emprestimo)swipeItem.BindingContext;

        // Agora você pode acessar o ID ou qualquer outra propriedade do item
        int idDoItem = item.Id; // Substitua "Id" pelo nome da propriedade que contém o ID

        Navigation.PushModalAsync(new ModalCancelar(idDoItem));
    }
}