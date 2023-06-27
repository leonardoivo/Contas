

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Contas.Service.Services;
using Contas.Service.Interfaces;
using Contas.Application.ViewModels.Conta;

namespace Contas.Controllers
    [ApiController]
    [Route("Contas")]
    [Authorize]
    public class ContaController : ControllerBase
    {
        private IContaService _contaService;

        public ContaController(IContaService contaService)
        {

        _contaService = contaService;


        }

        [HttpGet]
        public IList<ContaViewModel> Buscar()
        {

            return _contaService.ListarContas();

        }

        [HttpPost]
        public ActionResult<ContaViewModel> Criar([FromBody] ContaViewModel viewModel)
        {
        _contaService.InserirConta(viewModel);
            return NoContent();

        }

        [HttpPut]
        public ActionResult<ContaViewModel> Alterar(
            [FromBody] ContaViewModel viewModel)
        {
        _contaService.AlterarCliente(viewModel);
            return NoContent();

        }

        [HttpDelete("{clienteId:int}")]
        public ActionResult<ContaViewModel> Deletar(int id)
        {
        _contaService.DeletarCliente(id);
            return NoContent();
        }
    }
}
