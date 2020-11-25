using MeuPrimeiroAppXamarin.Classes;
using Xamarin.Forms;

namespace MeuPrimeiroAppXamarin.Views
{
    public partial class AgendamentoView : ContentPage
    {
        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();

            this.Title = veiculo.Nome + " - agendamento";
        }
    }
}