using Epi_Care_Planner.Model;
using Epi_Care_Planner.Pages.FuncionarioPages;

namespace Epi_Care_Planner.Pages.Modal;

public partial class ModalEpiFuncionario : ContentPage
{
    Usuario usuario = new Usuario();
    Epi epi = new Epi();
	public ModalEpiFuncionario(Usuario user, Epi epiEdite)
	{
		InitializeComponent();
        usuario = user;
        epi = epiEdite;
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
    private void btnSolicitarEpi_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new SolicitacaoPage(usuario));
    }
    private void btnvoltar_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}