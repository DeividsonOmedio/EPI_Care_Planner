using Epi_Care_Planner.Context;
using Epi_Care_Planner.Model;

namespace Epi_Care_Planner.Pages.Modal;

public partial class ModalEditarEpi : ContentPage
{
    AppDbContext _context = new AppDbContext();
    Epi epi = new Epi();
    public ModalEditarEpi(Epi epiEditar)
	{
        epi = epiEditar;
		InitializeComponent();
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
private void btnConfirmarEpi_Clicked(object sender, EventArgs e)
    {
        var result = _context.epis.FirstOrDefault(x => x.Id == epi.Id);
        if (result == null)
        {
            DisplayAlert("Atenção", "error", "Fechar");
            return;
        }
        _context.epis.Update(result);
        _context.SaveChanges();
        Navigation.PopModalAsync();
    }

    private void btnvoltar_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}