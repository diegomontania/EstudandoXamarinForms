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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "Proximo", (msg)=> 
            {
                //chama a próxima página
                Navigation.PushAsync(new AgendamentoView(msg));
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "Proximo");
        }
    }
}