using System;
using System.Collections.Generic;
using System.Text;

namespace MeuPrimeiroAppXamarin.Classes
{
    //classe com as propriedades do veiculo
    public class VeiculoModel
    {
        public const int FREIO_ABS = 800;
        public const int AR_CONDICIONADO = 1000;
        public const int MP3_PLAYER = 500;

        public string Nome { get; set; }
        public int Ano { get; set; }
        public decimal Preco { get; set; }
        public string PrecoFormatado 
        {
            get { return string.Format($"R${Preco}"); }
        }

        //public string PrecoTotalFormatado { get; internal set; }

        public bool FreioAbsSelecionado;
        public bool ArCondicionadoSelecionado;
        public bool Mp3PlayerSelecionado;

        public VeiculoModel()
        {

        }

        public decimal PrecoTotalFormatado(decimal precoVeiculo)
        {
            var total = precoVeiculo
                + (FreioAbsSelecionado ? FREIO_ABS : 0)
                + (ArCondicionadoSelecionado ? AR_CONDICIONADO : 0)
                + (Mp3PlayerSelecionado ? MP3_PLAYER : 0);

            return total;
        }
    }
}
