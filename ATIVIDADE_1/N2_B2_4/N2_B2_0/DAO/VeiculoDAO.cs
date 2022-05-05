using N2_B2_0.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace N2_B2_0.DAO
{
    public class VeiculoDAO : PadraoDAO<VeiculoViewModel>
    {
        protected override SqlParameter[] CriaParametros(VeiculoViewModel model)
        {
            object imgByte = model.ImagemEmByte;

            if (imgByte == null)
                imgByte = DBNull.Value;

            SqlParameter[] parametros =
            {
                new SqlParameter("ID", model.ID),                
                new SqlParameter("UltimaRevisao", model.UltimaRevisao),
                new SqlParameter("Quilometragem", model.Quilometragem),
                new SqlParameter("Cor", model.Cor),
                new SqlParameter("Placa", model.Placa),
                new SqlParameter("ID_Categoria", model.ID_Categoria),
                new SqlParameter("Imagem", imgByte)

            };
            return parametros;
        }
        protected override VeiculoViewModel MontaModel(DataRow registro)
        {
            VeiculoViewModel c = new VeiculoViewModel();

            c.ID = Convert.ToInt32(registro["ID"]);            
            c.UltimaRevisao = Convert.ToDateTime(registro["UltimaRevisao"]);
            c.Quilometragem = Convert.ToInt32(registro["Quilometragem"]);
            c.Cor = registro["Cor"].ToString();
            c.Placa = registro["Placa"].ToString();
            c.ID_Categoria = Convert.ToInt32(registro["ID_Categoria"]);

            if (registro["Imagem"] != DBNull.Value)
                c.ImagemEmByte = registro["Imagem"] as byte[];

            return c;
        }
        protected override void SetTabela()
        {
            Tabela = "Veiculo";
        }
    }
}
