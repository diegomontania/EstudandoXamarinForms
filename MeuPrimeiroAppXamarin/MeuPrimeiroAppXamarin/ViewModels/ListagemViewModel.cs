using MeuPrimeiroAppXamarin.Classes;
using MeuPrimeiroAppXamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MeuPrimeiroAppXamarin.ViewModels
{
    public class ListagemViewModel
    {
        //cria propriedade que receberá a lista de veiculos
        public List<Veiculo> Veiculos { get; set; }

        //propriedade responsavel por selecioanr o veiculo. O tipo do proprio item que esta sendo usado na lista
        private Veiculo veiculoSelecionado;
        public Veiculo VeiculoSelecionado
        {
            get { return veiculoSelecionado; }
            set
            {
                veiculoSelecionado = value;

                //utilizando a "Mensageria" para executar uma ação
                if(value != null) /*Se nao for nulo*/
                    MessagingCenter.Send(veiculoSelecionado, "VeiculoSelecionado");
            }
        }

        public string TituloInicial { get; set; }

        public ListagemViewModel()
        {
            this.Veiculos = new ListagemVeiculos().Veiculos;
            this.TituloInicial = "Test Drive - Veículos";
        }
    }
}
