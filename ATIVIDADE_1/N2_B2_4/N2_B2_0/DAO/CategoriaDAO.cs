using N2_B2_0.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace N2_B2_0.DAO
{
    public class CategoriaDAO : PadraoDAO<CategoriaViewModel>
    {
        protected override SqlParameter[] CriaParametros(CategoriaViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[4]; 
            parametros[0] = new SqlParameter("ID", model.ID);
            parametros[1] = new SqlParameter("Descricao", model.Descricao);
            parametros[2] = new SqlParameter("Finalidade", model.Finalidade);
            parametros[3] = new SqlParameter("Tamanho", model.Tamanho);            
            return parametros;
        }

        protected override CategoriaViewModel MontaModel(DataRow registro)
        {
            CategoriaViewModel a = new CategoriaViewModel();

            a.ID = Convert.ToInt32(registro["ID"]);
            a.Descricao = registro["Descricao"].ToString();
            a.Finalidade = registro["Finalidade"].ToString();
            a.Tamanho = registro["Tamanho"].ToString();

            return a;
        }

        protected override void SetTabela()
        {
            Tabela = "Categoria";
        }
    }
}
