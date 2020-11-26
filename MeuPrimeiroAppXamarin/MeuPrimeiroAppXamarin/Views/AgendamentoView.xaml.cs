using MeuPrimeiroAppXamarin.Classes;
using System;
using Xamarin.Forms;

namespace MeuPrimeiroAppXamarin.Views
{
    public partial class AgendamentoView : ContentPage
    {
        public Veiculo Veiculo { get; set; }

        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public DateTime DataAgendamento { get; set; }
        public TimeSpan HoraAgendamento { get; set; }

        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            this.Veiculo = veiculo;
            this.Title = veiculo.Nome + " - Agendamento";
            this.DataAgendamento = DateTime.Now;
            this.BindingContext = this;
        }

        private void btnAgendamento_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Agendamento concluído!", 
                $"{Nome}, seu agendamento para o dia {DataAgendamento} as {HoraAgendamento}, " +
                $"foi agendado com sucesso!", 
                "ok");
        }
    }
}