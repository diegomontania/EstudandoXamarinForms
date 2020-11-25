using System;
using System.Collections.Generic;
using System.Text;

namespace MeuPrimeiroAppXamarin.Classes
{
    //classe com as propriedades do veiculo
    public class Veiculo
    {
        public string Nome { get; set; }
        public int Ano { get; set; }
        public decimal Preco { get; set; }
        public string PrecoFormatado 
        {
            get { return string.Format("R${0}", Preco); }
        }

        public Veiculo()
        {

        }
    }
}
