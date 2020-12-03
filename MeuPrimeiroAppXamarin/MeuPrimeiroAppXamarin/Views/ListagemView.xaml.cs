using MeuPrimeiroAppXamarin.Classes;
using MeuPrimeiroAppXamarin.Models;
using MeuPrimeiroAppXamarin.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MeuPrimeiroAppXamarin.Views
{
    public partial class ListagemView : ContentPage
    {
        public ListagemViewModel ViewModel { get; set; }

        public ListagemView()
        {
            InitializeComponent();

            //fazendo "Binding" das informações vindas do xaml, passando o contexto de binding para a classe.
            this.ViewModel = new ListagemViewModel();
            this.BindingContext = this.ViewModel;
        }

        //Ao abrir a view
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            //Assinando a mensagem
            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado", 
                //funcao anonima que recebe e trata a mensagem e faz a execucao para a próxima pagina
                (msg) =>
                { 
                    Navigation.PushAsync(new DetalheView(msg)); //chama a próxima página
                });

            //faz request da api ao abrir a view
            await this.ViewModel.GetVeiculos();
        }

        //cancelando assinatura : evita criar multiplas mensagem do mesmo evento
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
        }
    }
}
