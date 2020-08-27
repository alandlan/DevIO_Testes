using System;
using System.Collections.Generic;
using System.Text;

namespace BancoX.Model.DadosBancarios
{
    public  class Conta
    {
        public int Numero { get; set; }
        public int Agencia { get; set; }
        public int Digito { get; set; }
        public TipoConta TipoConta { get; set; }
        public float Saldo { get; set; }
    }
}
