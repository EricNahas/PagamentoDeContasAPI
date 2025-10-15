using Microsoft.AspNetCore.Mvc;
using ProjetoDeliverIT.Enumerators;
using ProjetoDeliverIT.Models;
using ProjetoDeliverIT.Services;
using ProjetoDeliverIT.Utils;

namespace ProjetoDeliverIT.Controllers
{

    /// <summary>
    /// Controlador responsável pelo gerenciamento de contas.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly IContaService _service;

        public ContaController(IContaService service)
        {
            _service = service;
        }

        /// <summary>
        /// Persiste uma Conta 
        /// </summary>
        /// <returns>Mensagem de Retorno e Objeto persistido</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Conta bill)
        {
            if (!ModelState.IsValid)
            {
                var erros = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                RetornoAPI retorno = ResponseUtils.RetornoSucessoErro(StatusRetornoAPI.ErroModelState, MensagemRetornoAPI.ErroModelState, erros);

                return ResponseUtils.RetornarRequisicaoResposta(this, retorno);
            }

            RetornoAPI result = _service.Insert(bill);

            return ResponseUtils.RetornarRequisicaoResposta(this, result);
        }

        /// <summary>
        /// Retorna todas as Contas cadastradas
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            var bills = _service.GetAll();
            return Ok(bills);
        }
    }
}
