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
        public ListagemView()
        {
            InitializeComponent();

            //fazendo "Binding" das informações vindas do xaml, passando o contexto de binding para a classe.
            this.BindingContext = new ListagemViewModel();
        }

        private void ListViewVeiculos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var veiculo = (Veiculo)e.Item; /*convertendo um objeto genérico para um objeto veiculo*/

            //coloca uma nova página em cima da página atual fazendo uma 'pilha de navegação'
            Navigation.PushAsync(new DetalheView(veiculo)); //chama a próxima página
        }
    }
}
