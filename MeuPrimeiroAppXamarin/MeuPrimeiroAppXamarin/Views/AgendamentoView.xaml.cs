using MeuPrimeiroAppXamarin.Classes;
using MeuPrimeiroAppXamarin.Models;
using MeuPrimeiroAppXamarin.ViewModels;
using System;
using Xamarin.Forms;

namespace MeuPrimeiroAppXamarin.Views
{
    public partial class AgendamentoView : ContentPage
    {
        public AgendamentoViewModel ViewModel { get; set; }

        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            this.ViewModel = new AgendamentoViewModel(veiculo);
            this.BindingContext = this.ViewModel;
            this.Title = veiculo.Nome + " - Agendamento";
        }

        private void BtnAgendamento_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Agendamento",
            string.Format(
            @"
            Veiculo: {0}
            Nome: {1}
            Fone: {2}
            E-mail: {3}
            Data Agendamento: {4}
            Hora Agendamento: {5}",
            ViewModel.Agendamento.Veiculo.Nome,
            ViewModel.Agendamento.Nome,
            ViewModel.Agendamento.Telefone,
            ViewModel.Agendamento.Email,
            ViewModel.Agendamento.DataAgendamento.ToString("dd/MM/yyyy"),
            ViewModel.Agendamento.HoraAgendamento.ToString("hh\\:mm")), "OK");
        }
    }
}