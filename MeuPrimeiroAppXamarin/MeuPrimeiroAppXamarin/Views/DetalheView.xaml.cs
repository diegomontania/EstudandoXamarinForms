using MeuPrimeiroAppXamarin.Classes;
using System;
using Xamarin.Forms;

namespace MeuPrimeiroAppXamarin.Views
{
    public partial class DetalheView : ContentPage
    {
        public VeiculoModel Veiculo { get; set; }

        public string FreioAbs 
        {   
            get
            {
                return string.Format($"Freio ABS - R$ {VeiculoModel.FREIO_ABS}");
            }
        }
        public string ArCondicionado
        {
            get
            {
                return string.Format($"Ar Condicionado - R$ {VeiculoModel.AR_CONDICIONADO}");
            }
        }
        public string Mp3Player
        {
            get
            {
                return string.Format($"Mp3 Player - R$ {VeiculoModel.MP3_PLAYER}");
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

        public DetalheView(VeiculoModel veiculo)
        {
            InitializeComponent();
            this.Title = veiculo.Nome + " - Detalhes";
            this.Veiculo = veiculo;
            this.BindingContext = this;
        }

        private void btnProximaPagina_Clicked(object sender, EventArgs e)
        {
            //chama a próxima página
            Navigation.PushAsync(new AgendamentoView(Veiculo));
        }
    }
}