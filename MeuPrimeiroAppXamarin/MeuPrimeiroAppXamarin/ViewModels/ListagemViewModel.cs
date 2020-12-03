using MeuPrimeiroAppXamarin.Classes;
using MeuPrimeiroAppXamarin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MeuPrimeiroAppXamarin.ViewModels
{
    public class ListagemViewModel : BaseViewModel
    {
        //url da api
        const string URL_GET_VEICULOS = "http://aluracar.herokuapp.com/";

        //cria propriedade que receberá a lista de veiculos da api
        //precisa ser um 'ObservableCollection' que possa ser observada pela view, para quando for atualizada os dados possam ser exibidos
        public ObservableCollection<Veiculo> Veiculos { get; set; }

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

        //propriedade responsavel fazer o 'loading' na tela
        private bool aguarde;
        public bool AguardandoCarregamento
        {
            get { return aguarde; }
            set 
            { 
                aguarde = value;
                OnPropertyChanged();
            }
        }

        public ListagemViewModel()
        {
            this.TituloInicial = "Test Drive - Veículos";
            this.Veiculos = new ObservableCollection<Veiculo>();
        }

        //responsavel por receber a api
        public async Task GetVeiculos()
        {
            //coloca propriedade como true, antes de receber os a listagem para que o 'loading' apareça
            AguardandoCarregamento = true;

            HttpClient cliente = new HttpClient();  /*cliente http responsável por enviar e receber respostas HTTP*/
            var resultado = await cliente.GetStringAsync(URL_GET_VEICULOS); /*acessa e aguarda as informações da url*/

            //Converte array da requisição em array de objetos
            var veiculosJson = JsonConvert.DeserializeObject<VeiculoJson[]>(resultado);

            //após resposta da requisição muda para false, para que o 'loading' desapareça
            AguardandoCarregamento = false;

            //populando lista, criando novos veiculos recebendo os valores da api
            foreach (var veiculo in veiculosJson)
            {
                this.Veiculos.Add(new Veiculo
                {
                    Nome = veiculo.nome,
                    Preco = veiculo.preco
                });
            }
        }

    }

    //criando classe com propriedades com letra minuscula para não dar conflito com o json
    //ja que, a classe 'Veiculo' possui Letras maiusculas em sua declaração
    //ps : como fazer isso aqui de uma melhor forma?
    class VeiculoJson
    {
        public string nome { get; set; }
        public int preco { get; set; }
    }
}
