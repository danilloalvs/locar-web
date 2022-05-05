using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace N2_B2_0.DAO
{
    public static class ConexaoBD
    {
        public static SqlConnection GetConexao()
        {
            //string strCon = "Data Source=KAIO\\SQLEXPRESS; Database=LocacaoVeiculo; integrated security=true";
            string strCon = "Data Source=LOCALHOST\\SQLSERVER; Database=LocacaoVeiculo; integrated security=true";
            SqlConnection conexao = new SqlConnection(strCon);
            conexao.Open();
            return conexao;
        }
    }
}
