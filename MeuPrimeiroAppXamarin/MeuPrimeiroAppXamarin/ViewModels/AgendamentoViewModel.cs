using MeuPrimeiroAppXamarin.Classes;
using MeuPrimeiroAppXamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeuPrimeiroAppXamarin.ViewModels
{
    public class AgendamentoViewModel
    {
        public Agendamento Agendamento { get; set; }
        public Veiculo Veiculo
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

        public AgendamentoViewModel(Veiculo veiculo)
        {
            this.Agendamento = new Agendamento();
            this.Agendamento.Veiculo = veiculo;
            this.DataAgendamento = DateTime.Today;
            this.HoraAgendamento = DateTime.Now.TimeOfDay;
        }
    }
}
