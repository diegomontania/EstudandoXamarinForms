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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Agendamento>(this, "Agendamento", async (msg) =>
            {
                var confirmaUsuario = await DisplayAlert("Salvar Agendamento", "Deseja enviar o agendamento?", "Sim", "Não");

                if (confirmaUsuario)
                {
                    this.ViewModel.SalvarAgendamento();
                }
            });

            MessagingCenter.Subscribe<Agendamento>(this, "SucessoAgendamento", async (msg) =>
            {
                await DisplayAlert("Agendamento", "Agendamento salvo com sucesso", "Ok");
            });

            MessagingCenter.Subscribe<ArgumentException>(this, "FalhaAgendamento", async (msg) =>
            {
                await DisplayAlert("Agendamento", "Falha ao agendandar! Verifique os dados e tente novamente mais tarde!", "Ok");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "Agendamento");
            MessagingCenter.Unsubscribe<Agendamento>(this, "SucessoAgendamento");
            MessagingCenter.Unsubscribe<Agendamento>(this, "FalhaAgendamento");
        }
    }
}