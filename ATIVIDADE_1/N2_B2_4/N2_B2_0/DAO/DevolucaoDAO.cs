using N2_B2_0.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace N2_B2_0.DAO
{
    public class DevolucaoDAO : PadraoDAO<DevolucaoViewModel>
    {
        protected override SqlParameter[] CriaParametros(DevolucaoViewModel model)
        {
            SqlParameter[] parametros =
            {
                new SqlParameter("ID", model.ID),
                new SqlParameter("DataDevolucao", model.DataDevolucao),
                new SqlParameter("ValorDevolucao", model.ValorDevolucao),
                new SqlParameter("MetodoPagamento", model.MetodoPagamento),
                new SqlParameter("Observacoes", model.Observacoes),
                new SqlParameter("ID_Locacao", model.ID_Locacao)
            };
            return parametros;
        }
        protected override DevolucaoViewModel MontaModel(DataRow registro)
        {
            DevolucaoViewModel c = new DevolucaoViewModel();

            c.ID = Convert.ToInt32(registro["ID"]);
            c.DataDevolucao = Convert.ToDateTime(registro["DataDevolucao"]);
            c.ValorDevolucao = Convert.ToInt32(registro["ValorDevolucao"]);
            c.MetodoPagamento = registro["MetodoPagamento"].ToString();
            c.Observacoes = registro["Observacoes"].ToString();
            c.ID_Locacao = Convert.ToInt32(registro["ID_Locacao"]);

            return c;
        }
        protected override void SetTabela()
        {
            Tabela = "Devolucao";
        }
    }
}
