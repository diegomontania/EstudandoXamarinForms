using MeuPrimeiroAppXamarin.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using MeuPrimeiroAppXamarin.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace MeuPrimeiroAppXamarin.ViewModels
{
    public class DetalheViewModel : BaseViewModel
    {
        public Veiculo Veiculo { get; set; }
        public ICommand ProximoCommand { get; set; }

        public string FreioAbs
        {
            get
            {
                return string.Format($"Freio ABS - R$ {Veiculo.FREIO_ABS}");
            }
        }
        public string ArCondicionado
        {
            get
            {
                return string.Format($"Ar Condicionado - R$ {Veiculo.AR_CONDICIONADO}");
            }
        }
        public string Mp3Player
        {
            get
            {
                return string.Format($"Mp3 Player - R$ {Veiculo.MP3_PLAYER}");
            }
        }
        public bool TemFreioAbs
        {
            get
            {
                return Veiculo.FreioAbsSelecionado;
            }
            set
            {
                Veiculo.FreioAbsSelecionado = value;
                OnPropertyChanged(); /*notifica ao forms, que houve mudança de valor em uma propriedade do bind*/
                OnPropertyChanged(nameof(ValorTotal));
            }
        }
        public bool TemArCondicionado
        {
            get
            {
                return Veiculo.ArCondicionadoSelecionado;
            }
            set
            {
                Veiculo.ArCondicionadoSelecionado = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }
        public bool TemMp3Player
        {
            get
            {
                return Veiculo.Mp3PlayerSelecionado;
            }
            set
            {
                Veiculo.Mp3PlayerSelecionado = value;
                OnPropertyChanged();                    //chama metodo da classe herdada para que a view seja atualizada corretamente
                OnPropertyChanged(nameof(ValorTotal));
            }
        }
        public string ValorTotal
        {
            get
            {
                return string.Format($"Valor Total: R$ {Veiculo.PrecoTotalFormatado(Veiculo.Preco)}");
            }
        }

        public DetalheViewModel(Veiculo veiculo)
        {
            this.Veiculo = veiculo;

            /*instancia comando do botao*/
            this.ProximoCommand = new Command(() =>
            {
                MessagingCenter.Send(veiculo, "Proximo"); /*envia mensagem do botao utilizando MessagingCenter*/
            }); 
        }

        
    }
}
