using MeuPrimeiroAppXamarin.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeuPrimeiroAppXamarin.Models
{
    public class ListagemVeiculosModel
    {
        //cria propriedade que receberá a lista de veiculos
        public List<VeiculoModel> Veiculos { get; set; }

        public ListagemVeiculosModel()
        {
            //popula lista com valores
            Veiculos = new List<VeiculoModel>
            {
                new VeiculoModel { Nome = "Azera V6", Ano = 1994, Preco = 60000},
                new VeiculoModel { Nome = "Azera V7", Ano = 1996, Preco = 70000},
                new VeiculoModel { Nome = "Azera V8", Ano = 1999, Preco = 80000},
                new VeiculoModel { Nome = "Azera V9", Ano = 2000, Preco = 90000}
            };
        }
    }
}
