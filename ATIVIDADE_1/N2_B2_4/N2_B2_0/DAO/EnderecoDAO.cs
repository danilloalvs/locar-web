using N2_B2_0.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace N2_B2_0.DAO
{
    public class EnderecoDAO : PadraoDAO<EnderecoViewModel>
    {
        protected override SqlParameter[] CriaParametros(EnderecoViewModel model)
        {
            SqlParameter[] parametros =
            {
                new SqlParameter("ID", model.ID),
                new SqlParameter("CEP", model.CEP),
                new SqlParameter("Rua", model.Rua),
                new SqlParameter("Bairro", model.Bairro),
                new SqlParameter("Numero", model.Numero),
                new SqlParameter("Complemento", model.Complemento)                

            };
            return parametros;
        }
        protected override EnderecoViewModel MontaModel(DataRow registro)
        {
            EnderecoViewModel c = new EnderecoViewModel();

            c.ID = Convert.ToInt32(registro["ID"]);
            c.CEP = registro["CEP"].ToString();
            c.Rua = registro["Rua"].ToString();
            c.Bairro = registro["Bairro"].ToString();
            c.Numero = Convert.ToInt32(registro["Numero"]);
            c.Complemento = registro["Complemento"].ToString();            

            return c;
        }
        protected override void SetTabela()
        {
            Tabela = "Endereco";
        }
    }
}
