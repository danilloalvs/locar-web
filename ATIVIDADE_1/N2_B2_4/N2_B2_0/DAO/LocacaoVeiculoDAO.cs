using N2_B2_0.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace N2_B2_0.DAO
{
    public class LocacaoVeiculoDAO : PadraoDAO<LocacaoVeiculoViewModel>
    {
        protected override SqlParameter[] CriaParametros(LocacaoVeiculoViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[2];            
            parametros[0] = new SqlParameter("ID", model.ID);
            parametros[1] = new SqlParameter("ID_Veiculo", model.ID_Veiculo);
            return parametros;
        }

        protected override LocacaoVeiculoViewModel MontaModel(DataRow registro)
        {
            LocacaoVeiculoViewModel a = new LocacaoVeiculoViewModel();
            
            a.ID = Convert.ToInt32(registro["ID"]);
            a.ID_Veiculo = Convert.ToInt32(registro["ID_Veiculo"]);

            return a;
        }

        protected override void SetTabela()
        {
            Tabela = "LocacaoVeiculo";
        }
    }
}
