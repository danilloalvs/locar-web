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
    public class DevolucaoController : PadraoController<DevolucaoViewModel>
    {

        public DevolucaoController()
        {
            GeraProximoId = true;
            DAO = new DevolucaoDAO();
        }
        protected override void PreencheDadosParaView(string Operacao, DevolucaoViewModel model)
        {
            base.PreencheDadosParaView(Operacao, model);
            PreparaListaLocacoesParaCombo();
            if (Operacao == "I")
            {
                model.DataDevolucao = DateTime.Now;
            }
        }

        private void PreparaListaLocacoesParaCombo()
        {
            LocacaoDAO locacaoDAO = new LocacaoDAO();
            var locacoes = locacaoDAO.Listagem();
            List<SelectListItem> listaLocacoes= new List<SelectListItem>();
            listaLocacoes.Add(new SelectListItem("Selecione uma locação...", "0"));
            foreach (var locacao in locacoes)
            {
                SelectListItem item = new SelectListItem(locacao.ID.ToString(), locacao.ID.ToString());
                listaLocacoes.Add(item);
            }
            ViewBag.Locacoes = listaLocacoes;
        }

        protected override void ValidaDados(DevolucaoViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);

            if (string.IsNullOrEmpty(model.Observacoes))
                ModelState.AddModelError("Observacoes", "Preencha as observações");
            if (string.IsNullOrEmpty(model.MetodoPagamento))
                ModelState.AddModelError("MetodoPagamento", "Informe o metodo de pagamento");
            if (model.DataDevolucao > DateTime.Now)
                ModelState.AddModelError("DataDevolucao", "Data inválida!");
            if (model.ValorDevolucao <= 0)
                ModelState.AddModelError("ValorDevolucao", "Informe o valor da devolução");
        }

    }
}
