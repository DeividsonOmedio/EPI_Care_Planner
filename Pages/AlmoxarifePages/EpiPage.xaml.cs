using Epi_Care_Planner.Context;
using Epi_Care_Planner.Model;
using Epi_Care_Planner.Pages.Modal;

namespace Epi_Care_Planner.Pages.AlmoxarifePages;

public partial class EpiPage : ContentPage
{
    private AppDbContext _context = new AppDbContext();

    public EpiPage()
    {
        InitializeComponent();
        
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {

    }

    private void btnAdionarEpi_Clicked(object sender, EventArgs e)
    {
        btnBuscarEpi.IsVisible = false;
        tagBuscaEpi.IsVisible = false;
        tagAdicionarEpi.IsVisible = true;
        tagListarEpi.IsVisible = false;
        btnListarEpis.IsVisible = false;
        btnCancelarBusca.IsVisible = true;

    }

    private void btnBuscarEpi_Clicked(object sender, EventArgs e)
    {
        tagBuscaEpi.IsVisible = true;
        btnAdionarEpi.IsVisible = false;
        btnBuscarEpi.IsVisible = false;
        tagAdicionarEpi.IsVisible = false;
        tagListarEpi.IsVisible = false;
        btnListarEpis.IsVisible = false;
        btnCancelarBusca.IsVisible = true;
    }

    private void btnNovoEpi_Clicked(object sender, EventArgs e)
    {
        Epi novoEpi = new Epi();
        novoEpi.Codigo = txtCodigoNovoEpi.Text;
        novoEpi.Nome = txtNomeEpiNovo.Text;
        novoEpi.Descricao = txtDescricaoEpiNovo.Text;
        novoEpi.Categoria = txtCategoriaEpiNovo.Text;
        novoEpi.QuantidadeTotal = Convert.ToInt32(txtQuantidadeEpiNovo.Text);
        novoEpi.QuantidadeAtual = novoEpi.QuantidadeTotal;

        if (string.IsNullOrEmpty(novoEpi.Codigo) || string.IsNullOrEmpty(novoEpi.Nome) || string.IsNullOrEmpty(novoEpi.Descricao) || string.IsNullOrEmpty(novoEpi.Categoria) || novoEpi.QuantidadeAtual != 0)
        {
            DisplayAlert("Atencao", "Todos os campos devem er preenchidos", "Fechar");
            return;
        }
        else
        {
            _context.epis.Add(novoEpi);
            _context.SaveChanges();
            return;
        }
    }

    private void btnListarEpis_Clicked(object sender, EventArgs e)
    {

        List<Epi> listaEpi = _context.epis.ToList();
        ListaEpisBanco.ItemsSource = listaEpi;
        ListaEpisBanco.IsVisible = true;



        btnBuscarEpi.IsVisible = false;
        tagBuscaEpi.IsVisible = false;
        btnAdionarEpi.IsVisible = false;
        tagAdicionarEpi.IsVisible = false;
        tagListarEpi.IsVisible = true;
        btnListarEpis.IsVisible = true;
        btnCancelarBusca.IsVisible = true;
    }

    private void btnProcurarEpiPorNome_Clicked(object sender, EventArgs e)
    {
        var nomeBusca = txtNomeEpiBusca.Text;
        var result = _context.epis.FirstOrDefault(x => x.Nome.Contains(nomeBusca));
        if (result != null)
        {
            Navigation.PushModalAsync(new ModalEpi(result));

        }
        else
        {
            DisplayAlert("Atencao", "EPI não encontrado", "Fechar");
            return;
        }



    }

    private void btnProcurarEpiPorCodigo_Clicked(object sender, EventArgs e)
    {
        var codeBusca = txtCodigoEpiBusca.Text;
        var result = _context.epis.FirstOrDefault(x => x.Codigo == codeBusca);
        if (result != null)
        {
            Navigation.PushModalAsync(new ModalEpi(result));

        }
        else
        {
            DisplayAlert("Atencao", "EPI não encontrado", "Fechar");
            return;
        }
    }

    private void btnCancelarBusca_Clicked(object sender, EventArgs e)
    {
        btnBuscarEpi.IsVisible = true;
        tagBuscaEpi.IsVisible = false;
        btnAdionarEpi.IsVisible = true;
        tagAdicionarEpi.IsVisible = false;
        tagListarEpi.IsVisible = false;
        btnListarEpis.IsVisible = true;
        btnCancelarBusca.IsVisible = false;
        ListaEpisBanco.IsVisible = false;
    }


    private void detalhesSwipe_Invoked(object sender, EventArgs e)
    {
        SwipeItem swipeItem = (SwipeItem)sender;
        Epi item = (Epi)swipeItem.BindingContext;
        Navigation.PushModalAsync(new ModalEpi(item));
    }

}