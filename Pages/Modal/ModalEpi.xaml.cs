using Epi_Care_Planner.Model;

namespace Epi_Care_Planner.Pages.Modal;

public partial class ModalEpi : ContentPage
{
    Epi epi = new Epi();
	public ModalEpi(Epi epiEditar)
	{
		InitializeComponent();
        this.epi = epiEditar;
        carregarEpi();
	}
        public void carregarEpi()
    {
        txtCodigo.Text = epi.Codigo;
        txtNome.Text = epi.Nome;
        txtDescricao.Text = epi.Descricao;
        txtCategoria.Text = epi.Categoria;
        txtQuantidade.Text = epi.QuantidadeAtual.ToString();
    }

    private void btnEditarEpi_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new ModalEditarEpi(epi));
    }

    private void btnvoltar_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}