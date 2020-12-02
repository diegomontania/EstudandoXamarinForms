using MeuPrimeiroAppXamarin.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using MeuPrimeiroAppXamarin.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MeuPrimeiroAppXamarin.ViewModels
{
    public class DetalheViewModel : INotifyPropertyChanged
    {
        public Veiculo Veiculo { get; set; }

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
                OnPropertyChanged();
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
        }

        //implementa interface para que a view seja atualizada corretamente
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
