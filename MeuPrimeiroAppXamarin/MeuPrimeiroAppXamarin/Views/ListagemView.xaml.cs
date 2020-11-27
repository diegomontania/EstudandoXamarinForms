using MeuPrimeiroAppXamarin.Classes;
using MeuPrimeiroAppXamarin.Models;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MeuPrimeiroAppXamarin.Views
{
    public partial class ListagemView : ContentPage
    {
        //cria propriedade que receberá a lista de veiculos
        public List<VeiculoModel> Veiculos { get; set; }

        public string TituloInicial { get; set; }

        public ListagemView()
        {
            InitializeComponent();

            this.TituloInicial = "Test Drive - Início";
            this.Veiculos = new ListagemVeiculosModel().Veiculos;

            //PS: Os valores definidos aqui, são associados aos componentes xaml
            //diretamente no xaml, pelo "Binding". Porém é necessário passar o contexto de binding.
            //No caso atual, esta mesma classe
            this.BindingContext = this;
        }

        private void ListViewVeiculos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var veiculo = (VeiculoModel)e.Item; /*convertendo um objeto genérico para um objeto veiculo*/

            //coloca uma nova página em cima da página atual fazendo uma 'pilha de navegação'
            Navigation.PushAsync(new DetalheView(veiculo)); //chama a próxima página
        }
    }
}
