using MeuPrimeiroAppXamarin.Classes;
using MeuPrimeiroAppXamarin.ViewModels;
using System;
using Xamarin.Forms;

namespace MeuPrimeiroAppXamarin.Views
{
    public partial class DetalheView : ContentPage
    {
        public Veiculo Veiculo { get; set; }

        public DetalheView(Veiculo veiculo)
        {
            InitializeComponent();
            this.Veiculo = veiculo;
            this.Title = veiculo.Nome + " - Detalhes";
            this.BindingContext = new DetalheViewModel(veiculo);
        }

        private void btnProximaPagina_Clicked(object sender, EventArgs e)
        {
            //chama a próxima página
            Navigation.PushAsync(new AgendamentoView(Veiculo));
        }
    }
}