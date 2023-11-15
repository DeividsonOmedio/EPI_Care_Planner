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
        epi.Codigo = txtCodigo.Text;
        epi.Nome = txtNome.Text;
        epi.Descricao = txtDescricao.Text;
        epi.Categoria = txtCategoria.Text;
        epi.QuantidadeAtual = Convert.ToInt32(txtQuantidade.Text);

        try 
        {
        _context.epis.Update(epi);
        _context.SaveChanges();
        DisplayAlert("Sucesso", "Edição realizada", "Fechar");    
        Navigation.PopModalAsync();
        }
        catch
        {
            DisplayAlert("Atenção", "Error", "Fechar");
                Navigation.PopModalAsync();
        }
    }

    private void btnvoltar_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}