using Epi_Care_Planner.Context;
using Epi_Care_Planner.Model;
using Epi_Care_Planner.Pages.Modal;
using Microsoft.EntityFrameworkCore;

namespace Epi_Care_Planner.Pages.AdministradorPages;

public partial class EpiPage : ContentPage
{
    private AppDbContext _context = new AppDbContext();

    public EpiPage()
    {
        InitializeComponent();
        Inicializar();
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
        btnBuscarEpi.IsVisible = false;
        btnAdionarEpi.IsVisible = false;
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

        if(string.IsNullOrEmpty(novoEpi.Codigo) || string.IsNullOrEmpty(novoEpi.Nome) || string.IsNullOrEmpty(novoEpi.Descricao) || string.IsNullOrEmpty(novoEpi.Categoria) || novoEpi.QuantidadeAtual != 0)
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
        if(result != null)
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

    private void Inicializar()
    {
        

        using (var db = new AppDbContext())
        {
            var items = db.epis.FirstOrDefault(x => x.Nome == "Capacete");
            if (items == null)
            {
                Epi capacete = new Epi();
                capacete.Codigo = "0230";
                capacete.Nome = "Capacete";
                capacete.Descricao = "Protege, principalmente, a cabeça e pescoço e também os ombros contra os choques elétricos, perfurações e impactos.";
                capacete.Categoria = "Geral";
                capacete.QuantidadeTotal = 100;
                capacete.QuantidadeAtual = 100;

                Epi Luva = new Epi();
                Luva.Codigo = "0232";
                Luva.Nome = "Luva";
                Luva.Descricao = "Indispensáveil quando são executadas atividades com exposição de risco ao fogo/calor, frio, impactos, materiais cortantes, agentes químicos ou biológicos.";
                Luva.Categoria = "Geral";
                Luva.QuantidadeTotal = 100;
                Luva.QuantidadeAtual = 100;

                Epi Calcado = new Epi();
                Calcado.Codigo = "0235";
                Calcado.Nome = "Calçado";
                Calcado.Descricao = "Protege contra calor/fogo, frio e agentes químicos ou biológicos. Assim como a impactos, esmagamento e queda de materiais pontiagudos ou perfurantes, por exemplo.";
                Calcado.Categoria = "Geral; Solda";
                Calcado.QuantidadeTotal = 100;
                Calcado.QuantidadeAtual = 100;

                Epi auricular = new Epi();
                auricular.Codigo = "0240";
                auricular.Nome = "Protetor auricular";
                auricular.Descricao = "Ruídos acima de 85 decibéis(dB) são considerados prejudiciais para a saúde auditiva. Por isso, exigem tempo de exposição controlado. Al�m disso, a NR 15 determina que acima destes n�veis considerados aceitáveis, o empregador precisa adotar medidas para a segurança do colaborador.";
                auricular.Categoria = "Geral; solda";
                auricular.QuantidadeTotal = 100;
                auricular.QuantidadeAtual = 100;

                Epi oculos = new Epi();
                oculos.Codigo = "0270";
                oculos.Nome = "Óculos de proteção";
                oculos.Descricao = "Protegem a sa�de dos olhos no ambiente de trabalho. Alguns dos principais riscos são as fagulhas da área de serralheria e solda, calor, poeira, micropartículas de impacto, agentes qu�micos ou biológicos, entre outros.";
                oculos.Categoria = "Geral";
                oculos.QuantidadeTotal = 100;
                oculos.QuantidadeAtual = 100;

                Epi Mascara = new Epi();
                Mascara.Codigo = "0284";
                Mascara.Nome = "Máscaras de proteção";
                Mascara.Descricao = "Protege contra riscos biológicos ou químicos, calor, fumaça e frio, entre outros.";
                Mascara.Categoria = "Geral";
                Mascara.QuantidadeTotal = 100;
                Mascara.QuantidadeAtual = 100;


                Epi MascSolda = new Epi();
                MascSolda.Codigo = "0415";
                MascSolda.Nome = "Máscara de solda";
                MascSolda.Descricao = "Tem a função de proteção da face contra eventuais fagulhas e respingos, resultantes dos processos de solda";
                MascSolda.Categoria = "Solda";
                MascSolda.QuantidadeTotal = 50;
                MascSolda.QuantidadeAtual = 50;

                Epi Respirador = new Epi();
                Respirador.Codigo = "0430";
                Respirador.Nome = "Respirador";
                Respirador.Descricao = "Protege as vias respiratórias.";
                Respirador.Categoria = "Solda";
                Respirador.QuantidadeTotal = 50;
                Respirador.QuantidadeAtual = 50;

                Epi LuvasSoldador = new Epi();
                LuvasSoldador.Codigo = "0422";
                LuvasSoldador.Nome = "Luvas de Soldador";
                LuvasSoldador.Descricao = "protegem, principalmente, a cabeça e pescoço e também os ombros contra os choques elétricos, perfurações e impactos.";
                LuvasSoldador.Categoria = "Solda";
                LuvasSoldador.QuantidadeTotal = 50;
                LuvasSoldador.QuantidadeAtual = 50;


                Epi OculosSoldador = new Epi();
                OculosSoldador.Codigo = "0428";
                OculosSoldador.Nome = "Capacete";
                OculosSoldador.Descricao = "O trabalhador precisa usar óculos com proteção UV e juntamente com as m�scaras de solda, podemos considerar ambos como um dos principais EPI's para soldador, afinal o risco aos olhos do é EMINENTE, seja por conta da exposição, radiação e luminosidade intensa ou por conta da projeção de particulas VOLANTES que possam entrar em contato com os olhos, resultando em danos irreversíveis.";
                OculosSoldador.Categoria = "Solda";
                OculosSoldador.QuantidadeTotal = 50;
                OculosSoldador.QuantidadeAtual = 50;

                Epi Avental = new Epi();
                Avental.Codigo = "0456";
                Avental.Nome = "Avental de raspa";
                Avental.Descricao = "Resistente ao calor e proteje o usuário contra projeções de metal fundido e radiações.";
                Avental.Categoria = "Solda";
                Avental.QuantidadeTotal = 50;
                Avental.QuantidadeAtual = 50;
                db.epis.Add(capacete);
                db.epis.Add(Luva);
                db.epis.Add(Calcado);
                db.epis.Add(auricular);
                db.epis.Add(oculos);
                db.epis.Add(Mascara);
                db.epis.Add(MascSolda);
                db.epis.Add(Respirador);
                db.epis.Add(Luva);
                db.epis.Add(Avental);
                db.epis.Add(OculosSoldador);
                db.SaveChanges();
            }
        }
    }
}