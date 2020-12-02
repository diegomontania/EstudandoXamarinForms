using MeuPrimeiroAppXamarin.Classes;
using MeuPrimeiroAppXamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeuPrimeiroAppXamarin.ViewModels
{
    public class ListagemViewModel
    {
        //cria propriedade que receberá a lista de veiculos
        public List<Veiculo> Veiculos { get; set; }

        public string TituloInicial { get; set; }

        public ListagemViewModel()
        {
            this.Veiculos = new ListagemVeiculos().Veiculos;
            this.TituloInicial = "Test Drive - Veículos";
        }
    }
}
