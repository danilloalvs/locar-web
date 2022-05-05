using N2_B2_0.DAO;
using N2_B2_0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N2_B2_0.Controllers
{
    public class CategoriaController : PadraoController<CategoriaViewModel>
    {

        public CategoriaController()
        {
            GeraProximoId = true;
            DAO = new CategoriaDAO();
        }

        protected override void PreencheDadosParaView(string Operacao, CategoriaViewModel model)
        {
            base.PreencheDadosParaView(Operacao, model); 
        }

        protected override void ValidaDados(CategoriaViewModel model, string operacao)
        {            
                base.ValidaDados(model, operacao);

                if (string.IsNullOrEmpty(model.Descricao))
                    ModelState.AddModelError("Descricao", "Preencha a Descrição.");
                if (string.IsNullOrEmpty(model.Finalidade))
                    ModelState.AddModelError("Finalidade", "Preencha a Finalidade.");
                if (string.IsNullOrEmpty(model.Tamanho))
                    ModelState.AddModelError("Tamanho", "Preencha o Tamanho.");                     
        }

    }
}
