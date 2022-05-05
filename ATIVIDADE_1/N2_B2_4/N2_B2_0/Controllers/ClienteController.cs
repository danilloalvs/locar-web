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
    public class ClienteController : PadraoController<ClienteViewModel>
    {
        public ClienteController()
        {
            GeraProximoId = true;
            DAO = new ClienteDAO();          
        }


        protected override void PreencheDadosParaView(string Operacao, ClienteViewModel model)
        {
            base.PreencheDadosParaView(Operacao, model);            
            PreparaListaEnderecosParaCombo();
            if (Operacao == "I")
            {
                model.DataCadastro = DateTime.Now;                
            }
        }

        private void PreparaListaEnderecosParaCombo()
        {
            EnderecoDAO enderecoDAO = new EnderecoDAO();
            var enderecos = enderecoDAO.Listagem();
            List<SelectListItem> listaEnderecos = new List<SelectListItem>();
            listaEnderecos.Add(new SelectListItem("Selecione um endereço...", "0"));
            foreach (var endereco in enderecos)
            {
                SelectListItem item = new SelectListItem("CEP: " + endereco.CEP + ", Número: " + endereco.Numero, endereco.ID.ToString());
                listaEnderecos.Add(item);
            }
            ViewBag.Enderecos = listaEnderecos;
        }


        protected override void ValidaDados(ClienteViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);

            if (string.IsNullOrEmpty(model.Nome))
                ModelState.AddModelError("Nome", "Preencha o nome.");
            if (string.IsNullOrEmpty(model.CPF))
                ModelState.AddModelError("CPF", "Informe o CPF");
            if (string.IsNullOrEmpty(model.Email))
                ModelState.AddModelError("Email", "Informe o e-mail.");
            if (string.IsNullOrEmpty(model.Telefone))
                ModelState.AddModelError("Telefone", "Informe o telefone.");
            if (model.DataCadastro > DateTime.Now)
                ModelState.AddModelError("DataCadastro", "Data inválida!");
            if (model.ID_Endereco <= 0)
                ModelState.AddModelError("ID_Endereco", "Informe o ID do endereço");
        }
    }
}
