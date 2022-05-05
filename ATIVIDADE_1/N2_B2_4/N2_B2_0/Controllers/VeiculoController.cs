using N2_B2_0.DAO;
using N2_B2_0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace N2_B2_0.Controllers
{
    public class VeiculoController : PadraoController<VeiculoViewModel>
    {
        public VeiculoController()
        {
            GeraProximoId = true;
            DAO = new VeiculoDAO();
        }

        public byte[] ConvertImageToByte(IFormFile file)
        {
            if (file != null)
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    return ms.ToArray();
                }

            else
                return null;
        }

        protected override void PreencheDadosParaView(string Operacao, VeiculoViewModel model)
        {
            base.PreencheDadosParaView(Operacao, model);
            PreparaListaCategoriasParaCombo();
            if (Operacao == "I")
            {
                model.UltimaRevisao = DateTime.Now;
            }
        }

        private void PreparaListaCategoriasParaCombo()
        {
            CategoriaDAO categoriaDAO = new CategoriaDAO();
            var categorias = categoriaDAO.Listagem();
            List<SelectListItem> listaCategorias = new List<SelectListItem>();
            listaCategorias.Add(new SelectListItem("Selecione uma categoria...", "0"));
            foreach (var categoria in categorias)
            {
                SelectListItem item = new SelectListItem(categoria.Descricao, categoria.ID.ToString());
                listaCategorias.Add(item);
            }
            ViewBag.Categorias = listaCategorias;
        }

        protected override void ValidaDados(VeiculoViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);

            if (string.IsNullOrEmpty(model.Placa))
                ModelState.AddModelError("Placa", "Informe a placa.");
            if (string.IsNullOrEmpty(model.Cor))
                ModelState.AddModelError("Cor", "Informe a cor.");
            if (model.UltimaRevisao > DateTime.Now)
                ModelState.AddModelError("UltimaRevisao", "Data inválida!");
            if (model.Quilometragem <= 0)
                ModelState.AddModelError("Quilometragem", "Informe a quilometragem");
            if (model.ID_Categoria <= 0)
                ModelState.AddModelError("ID_Categoria", "Informe o ID da categoria");
            if (model.Imagem == null && operacao == "I")
                ModelState.AddModelError("Imagem", "Escolha uma imagem.");
            if (model.Imagem != null && model.Imagem.Length / 1024 / 1024 >= 2)
                ModelState.AddModelError("Imagem", "Imagem limitada a 2 mb.");
            if (ModelState.IsValid)
            {                 //na alteração, se não foi informada a imagem, iremos manter a que já estava salva.
                if (operacao == "A" && model.Imagem == null)
                {
                    VeiculoViewModel cid = DAO.Consulta(model.ID);
                    model.ImagemEmByte = cid.ImagemEmByte;
                }
                else
                {
                    model.ImagemEmByte = ConvertImageToByte(model.Imagem);
                }
            }

        }
    }
}
