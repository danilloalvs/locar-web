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
    public class LocacaoController : PadraoController<LocacaoViewModel>
    {
        public LocacaoController()
        {
            GeraProximoId = true;
            DAO = new LocacaoDAO();
        }

        public virtual IActionResult Sobre()
        {            
            return View("Sobre");
        }

        protected override void PreencheDadosParaView(string Operacao, LocacaoViewModel model)
        {
            base.PreencheDadosParaView(Operacao, model);
            PreparaListaClientesParaCombo();
            
            if (Operacao == "I")
            {
                model.DataLocacao = DateTime.Now;                
            }
        }

        private void PreparaListaClientesParaCombo()
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            var clientes = clienteDAO.Listagem();
            List<SelectListItem> listaClientes = new List<SelectListItem>();
            listaClientes.Add(new SelectListItem("Selecione um cliente...", "0"));
            foreach (var cliente in clientes)
            {
                SelectListItem item = new SelectListItem(cliente.Nome, cliente.ID.ToString());
                listaClientes.Add(item);
            }
            ViewBag.Clientes = listaClientes;
        }

        protected override void ValidaDados(LocacaoViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);

            if (string.IsNullOrEmpty(model.StatusLocacao))
                ModelState.AddModelError("StatusLocacao", "Informe o Status.");
            if (model.DataLocacao > DateTime.Now)
                ModelState.AddModelError("DataLocacao", "Data de Locação inválida!");
            if (model.Valor <= 0)
                ModelState.AddModelError("Valor", "Informe o Valor");
            if (model.Valor <= 0)
                ModelState.AddModelError("ID_Cliente", "Informe o ID do cliente");
        }

    }
}
