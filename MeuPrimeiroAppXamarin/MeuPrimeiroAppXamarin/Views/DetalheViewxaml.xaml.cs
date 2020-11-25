using MeuPrimeiroAppXamarin.Classes;
using Xamarin.Forms;

namespace MeuPrimeiroAppXamarin.Views
{
    public partial class DetalheViewxaml : ContentPage
    {
        public Veiculo Veiculo { get; set; }

        public DetalheViewxaml(Veiculo veiculo)
        {
            InitializeComponent();
            this.Title = veiculo.Nome + " - detalhes";
            this.Veiculo = veiculo;
        }

        private void btnProximaPagina_Clicked(object sender, System.EventArgs e)
        {
            //chama a próxima página
            Navigation.PushAsync(new AgendamentoView(Veiculo));
        }
    }
}