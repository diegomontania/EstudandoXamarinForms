using MeuPrimeiroAppXamarin.Classes;
using Xamarin.Forms;

namespace MeuPrimeiroAppXamarin.Views
{
    public partial class AgendamentoView : ContentPage
    {
        public Veiculo Veiculo { get; set; }

        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            this.Veiculo = veiculo;
            this.Title = veiculo.Nome + " - Agendamento";
            this.BindingContext = this;
        }
    }
}