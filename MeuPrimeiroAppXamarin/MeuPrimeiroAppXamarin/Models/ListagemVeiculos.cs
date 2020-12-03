using MeuPrimeiroAppXamarin.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeuPrimeiroAppXamarin.Models
{
    public class ListagemVeiculos
    {
        //cria propriedade que receberá a lista de veiculos
        public List<Veiculo> Veiculos { get; set; }

        public ListagemVeiculos()
        {
            //popula lista com valores
            Veiculos = new List<Veiculo>
            {
                new Veiculo { Nome = "Azera V6", Ano = 2011, Preco = 40000, Imagem = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcThPFOhR0HeMDjhZioyttgedKIykhvZfZP_Ow&usqp=CAU"},
                new Veiculo { Nome = "Ford Ka", Ano = 2016, Preco = 10000, Imagem = "https://crasa.com.br/wp-content/uploads/2016/04/ford-ka-sedan-crasa1.png"},
                new Veiculo { Nome = "Golf", Ano = 2006, Preco = 20000, Imagem = "https://wp.vigomotors.com.br/wp-content/uploads/2018/07/thumb-1.jpg"},
                new Veiculo { Nome = "Sedan", Ano = 2017, Preco = 60000, Imagem = "https://staticimg.vicky.in/cache/images/cars/toyota/platinum-etios/toyota_platinum-etios_1-200x200.jpg"}
            };
        }
    }
}
