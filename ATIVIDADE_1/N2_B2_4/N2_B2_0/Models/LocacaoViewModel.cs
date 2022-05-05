using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N2_B2_0.Models
{
    public class LocacaoViewModel : PadraoViewModel
    {
        public DateTime DataLocacao { get; set; }        
        public string StatusLocacao { get; set; }
        public double Valor { get; set; }
        public int QtdVeiculos { get; set; }
        public int ID_Cliente{ get; set; }        
    }
}
