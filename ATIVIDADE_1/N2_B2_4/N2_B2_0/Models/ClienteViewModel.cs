using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N2_B2_0.Models
{
    public class ClienteViewModel : PadraoViewModel
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
        public int ID_Endereco { get; set; }

    }
}
