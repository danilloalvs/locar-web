using N2_B2_0.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace N2_B2_0.DAO
{
    public class ClienteDAO : PadraoDAO<ClienteViewModel>
    {
        protected override SqlParameter[] CriaParametros(ClienteViewModel model)
        {
            SqlParameter[] parametros =
            {
                new SqlParameter("ID", model.ID),
                new SqlParameter("CPF", model.CPF),
                new SqlParameter("Nome", model.Nome),
                new SqlParameter("Email", model.Email),
                new SqlParameter("Telefone", model.Telefone),
                new SqlParameter("DataCadastro", model.DataCadastro),
                new SqlParameter("ID_Endereco", model.ID_Endereco)

            };
            return parametros;
        }
        protected override ClienteViewModel MontaModel(DataRow registro)
        {
            ClienteViewModel c = new ClienteViewModel();
            
            c.ID = Convert.ToInt32(registro["ID"]);
            c.CPF = registro["CPF"].ToString();
            c.Nome = registro["Nome"].ToString();
            c.Email = registro["Email"].ToString();
            c.Telefone = registro["Telefone"].ToString();
            c.DataCadastro = Convert.ToDateTime(registro["DataCadastro"]);
            c.ID_Endereco = Convert.ToInt32(registro["id"]);                        

            return c;
        }
        protected override void SetTabela()
        {
            Tabela = "Cliente";            
        }
    }
}
