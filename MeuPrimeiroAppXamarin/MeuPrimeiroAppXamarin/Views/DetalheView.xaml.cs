using MeuPrimeiroAppXamarin.Classes;
using System;
using Xamarin.Forms;

namespace MeuPrimeiroAppXamarin.Views
{
    public partial class DetalheView : ContentPage
    {
        private const int FREIO_ABS = 800;
        private const int AR_CONDICIONADO = 1000;
        private const int MP3_PLAYER = 500;

        public Veiculo Veiculo { get; set; }

        public string FreioAbs 
        {   
            get
            {
                return string.Format($"Freio ABS - R$ {FREIO_ABS}");
            }
        }
        public string ArCondicionado
        {
            get
            {
                return string.Format($"Ar Condicionado - R$ {AR_CONDICIONADO}");
            }
        }
        public string Mp3Player
        {
            get
            {
                return string.Format($"Mp3 Player - R$ {MP3_PLAYER}");
            }
        }

        private bool freioAbsSelecionado;
        public bool TemFreioAbs
        {
            get
            {
                return freioAbsSelecionado;
            }
            set
            {
                freioAbsSelecionado = value;
                OnPropertyChanged(); /*notifica ao forms, que houve mudança de valor em uma propriedade do bind*/
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        private bool arCondicionadoSelecionado;
        public bool TemArCondicionado
        {
            get
            {
                return arCondicionadoSelecionado;
            }
            set
            {
                arCondicionadoSelecionado = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        private bool mp3PlayerSelecionado;
        public bool TemMp3Player
        {
            get
            {
                return mp3PlayerSelecionado;
            }
            set
            {
                mp3PlayerSelecionado = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public string ValorTotal
        {
            get
            {
                return string.Format($"Valor Total: R$ {ValorTotalSomado(Veiculo.Preco)}");
            }
        }

        public DetalheView(Veiculo veiculo)
        {
            InitializeComponent();
            this.Title = veiculo.Nome + " - Detalhes";
            this.Veiculo = veiculo;
            this.BindingContext = this;
        }

        public decimal ValorTotalSomado(decimal precoVeiculo)
        {
            var total = precoVeiculo
                + (TemFreioAbs ? FREIO_ABS : 0) 
                + (TemArCondicionado ? AR_CONDICIONADO: 0)
                + (TemMp3Player ? MP3_PLAYER : 0);

            return total;
        }

        private void btnProximaPagina_Clicked(object sender, EventArgs e)
        {
            //chama a próxima página
            Navigation.PushAsync(new AgendamentoView(Veiculo));
        }
    }
}