using MeuPrimeiroAppXamarin.Classes;
using MeuPrimeiroAppXamarin.Models;
using System;
using Xamarin.Forms;

namespace MeuPrimeiroAppXamarin.Views
{
    public partial class AgendamentoView : ContentPage
    {
        public AgendamentoModel Agendamento { get; set; }
        public VeiculoModel Veiculo
        {
            get { return Agendamento.Veiculo; }
            set { Agendamento.Veiculo = value; }
        }

        public string Nome
        {
            get { return Agendamento.Nome; }
            set { Agendamento.Nome = value; }
        }
        public int Idade
        {
            get { return Agendamento.Idade; }
            set { Agendamento.Idade = value; }
        }
        public string Cpf
        {
            get { return Agendamento.Cpf; }
            set { Agendamento.Cpf = value; }
        }
        public string Telefone
        {
            get { return Agendamento.Telefone; }
            set { Agendamento.Telefone = value; }
        }
        public string Email
        {
            get { return Agendamento.Email; }
            set { Agendamento.Email = value; }
        }
        public DateTime DataAgendamento
        {
            get { return Agendamento.DataAgendamento; }
            set { Agendamento.DataAgendamento = value; }
        }
        public TimeSpan HoraAgendamento
        {
            get { return Agendamento.HoraAgendamento; }
            set { Agendamento.HoraAgendamento = value; }
        }

        public AgendamentoView(VeiculoModel veiculo)
        {
            InitializeComponent();
            this.Agendamento = new AgendamentoModel();
            this.Agendamento.Veiculo = veiculo;
            this.Title = veiculo.Nome + " - Agendamento";
            this.DataAgendamento = DateTime.Today;
            this.BindingContext = this;
        }

        private void BtnAgendamento_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Agendamento concluído!",
                $"O {Veiculo.Nome} foi selecionado. " +
                $"{Nome}, seu agendamento para o dia {DataAgendamento:dd/MM/yyyy} as {HoraAgendamento}, " +
                $"foi agendado com sucesso!",
                "ok");
        }
    }
}