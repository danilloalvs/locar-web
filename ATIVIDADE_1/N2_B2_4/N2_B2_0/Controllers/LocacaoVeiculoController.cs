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
    public class LocacaoVeiculoController : PadraoController<LocacaoVeiculoViewModel>
    {
        public LocacaoVeiculoController()
        {
            GeraProximoId = false;
            DAO = new LocacaoVeiculoDAO();
        }
        protected override void PreencheDadosParaView(string Operacao, LocacaoVeiculoViewModel model)
        {
            base.PreencheDadosParaView(Operacao, model);
            PreparaListaLocacoesParaCombo();
            PreparaListaVeiculosParaCombo();
        }

        private void PreparaListaLocacoesParaCombo()
        {
            LocacaoDAO locacaoDAO = new LocacaoDAO();
            var locacoes = locacaoDAO.Listagem();
            List<SelectListItem> listaLocacoes = new List<SelectListItem>();
            listaLocacoes.Add(new SelectListItem("Selecione uma locação...", "0"));
            foreach (var locacao in locacoes)
            {
                SelectListItem item = new SelectListItem(locacao.ID.ToString(), locacao.ID.ToString());
                listaLocacoes.Add(item);
            }
            ViewBag.Locacoes = listaLocacoes;
        }

        private void PreparaListaVeiculosParaCombo()
        {
            VeiculoDAO veiculoDAO = new VeiculoDAO();
            var veiculos = veiculoDAO.Listagem();
            List<SelectListItem> listaVeiculos = new List<SelectListItem>();
            listaVeiculos.Add(new SelectListItem("Selecione um veículo...", "0"));
            foreach (var veiculo in veiculos)
            {
                SelectListItem item = new SelectListItem(veiculo.Placa, veiculo.ID.ToString());
                listaVeiculos.Add(item);
            }
            ViewBag.Veiculos = listaVeiculos;
        }

        protected override void ValidaDados(LocacaoVeiculoViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);

            ModelState.Clear();

            if (model.ID <= 0)
                ModelState.AddModelError("ID", "Informe o ID da locação");
            if (model.ID_Veiculo <= 0)
                ModelState.AddModelError("ID_Veiculo", "Informe o ID do veículo");
            if (operacao == "A" && DAO.Consulta(model.ID) == null)
                ModelState.AddModelError("Id", "Este registro não existe!");
            if (model.ID <= 0)
                ModelState.AddModelError("Id", "Id inválido!");
        }
    }
}
