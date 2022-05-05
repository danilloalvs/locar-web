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
    public class EnderecoController : PadraoController<EnderecoViewModel>
    {
        public EnderecoController()
        {
            GeraProximoId = true;
            DAO = new EnderecoDAO();
        }
        protected override void ValidaDados(EnderecoViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);

            if (string.IsNullOrEmpty(model.CEP))
                ModelState.AddModelError("CEP", "Preencha o CEP.");
            if (string.IsNullOrEmpty(model.Rua))
                ModelState.AddModelError("Rua", "Informe a rua");
            if (string.IsNullOrEmpty(model.Bairro))
                ModelState.AddModelError("Bairro", "Informe o bairro");
            if (string.IsNullOrEmpty(model.Complemento))
                ModelState.AddModelError("Complemento", "Informe o complemento");
            if (model.Numero <= 0)
                ModelState.AddModelError("Numero", "Informe o número");
        }
    }
}
