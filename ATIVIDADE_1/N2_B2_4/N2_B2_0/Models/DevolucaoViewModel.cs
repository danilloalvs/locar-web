using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N2_B2_0.Models
{
    public class DevolucaoViewModel : PadraoViewModel
    {
        public DateTime DataDevolucao { get; set; }
        public double ValorDevolucao { get; set; }
        public string MetodoPagamento { get; set; }
        public string Observacoes { get; set; }
        public int ID_Locacao { get; set; }
    }
}
