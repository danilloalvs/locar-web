using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace N2_B2_0.Models
{
    public class VeiculoViewModel : PadraoViewModel
    {        
        public DateTime UltimaRevisao { get; set; }
        public int Quilometragem { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
        public int ID_Categoria { get; set; }

        /// <summary>
        /// Imagem recebida do form pelo controller        
        /// </summary>         
        public IFormFile Imagem { get; set; }
        /// <summary> 
        ///  Imagem em bytes pronta para ser salva
        ///  </summary>         
        public byte[] ImagemEmByte { get; set; }

        /// <summary>         
        /// Imagem usada para ser enviada ao form no formato para ser exibida         
        /// </summary>         
        public string ImagemEmBase64
        {
            get
            {
                if (ImagemEmByte != null)
                    return Convert.ToBase64String(ImagemEmByte);
                else
                    return string.Empty;
            }
        }
    }
}
