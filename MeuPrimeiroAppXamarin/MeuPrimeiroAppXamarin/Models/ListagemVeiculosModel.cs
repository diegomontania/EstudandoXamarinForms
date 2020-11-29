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
                new VeiculoModel { Nome = "Azera V6", Ano = 2011, Preco = 40000, ImagemVeiculo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcThPFOhR0HeMDjhZioyttgedKIykhvZfZP_Ow&usqp=CAU"},
                new VeiculoModel { Nome = "Ford Ka", Ano = 2016, Preco = 10000, ImagemVeiculo = "https://crasa.com.br/wp-content/uploads/2016/04/ford-ka-sedan-crasa1.png"},
                new VeiculoModel { Nome = "Golf", Ano = 2006, Preco = 20000, ImagemVeiculo = "https://wp.vigomotors.com.br/wp-content/uploads/2018/07/thumb-1.jpg"},
                new VeiculoModel { Nome = "Sedan", Ano = 2017, Preco = 60000, ImagemVeiculo = "https://staticimg.vicky.in/cache/images/cars/toyota/platinum-etios/toyota_platinum-etios_1-200x200.jpg"}
            };
        }
    }
}
