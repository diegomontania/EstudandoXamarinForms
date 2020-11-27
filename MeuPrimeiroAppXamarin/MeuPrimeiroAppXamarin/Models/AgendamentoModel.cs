using MeuPrimeiroAppXamarin.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeuPrimeiroAppXamarin.Models
{
    public class AgendamentoModel
    {
        public VeiculoModel Veiculo { get; set; }

        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public DateTime DataAgendamento { get; set; }
        public TimeSpan HoraAgendamento { get; set; }

        public AgendamentoModel()
        {

        }
    }
}
