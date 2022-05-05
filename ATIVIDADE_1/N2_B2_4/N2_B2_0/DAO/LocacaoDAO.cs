using N2_B2_0.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace N2_B2_0.DAO
{
    public class LocacaoDAO : PadraoDAO<LocacaoViewModel>
    {
        protected override SqlParameter[] CriaParametros(LocacaoViewModel model)
        {
            SqlParameter[] parametros =
            {
                new SqlParameter("ID", model.ID),
                new SqlParameter("DataLocacao", model.DataLocacao),                
                new SqlParameter("StatusLocacao", model.StatusLocacao),
                new SqlParameter("Valor", model.Valor),
                new SqlParameter("QtdVeiculos", model.QtdVeiculos),
                new SqlParameter("ID_Cliente", model.ID_Cliente),                

            };
            return parametros;
        }
        protected override LocacaoViewModel MontaModel(DataRow registro)
        {
            LocacaoViewModel c = new LocacaoViewModel();

            c.ID = Convert.ToInt32(registro["ID"]);
            c.DataLocacao = Convert.ToDateTime(registro["DataLocacao"]);            
            c.StatusLocacao = registro["StatusLocacao"].ToString();
            c.Valor = Convert.ToInt32(registro["Valor"]);
            c.QtdVeiculos = Convert.ToInt32(registro["QtdVeiculos"]);
            c.ID_Cliente = Convert.ToInt32(registro["ID_Cliente"]);            

            return c;
        }
        protected override void SetTabela()
        {
            Tabela = "Locacao";
        }
    }
}
