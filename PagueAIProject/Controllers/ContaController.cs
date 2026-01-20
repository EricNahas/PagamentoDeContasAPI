using Microsoft.AspNetCore.Mvc;
using ProjetoDeliverIT.Enumerators;
using ProjetoDeliverIT.EnumeratorsExtensions;
using ProjetoDeliverIT.IntegrationsInterfaces;
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
    public class ContaController : BaseController
    {
        private readonly IContaService _service;

        private readonly IRabbitMqPublisher _rabbitMqPublisher;


        public ContaController(IContaService service, IRabbitMqPublisher rabbitMqPublisher)
        {
            _service = service;
            _rabbitMqPublisher = rabbitMqPublisher;
        }

        /// <summary>
        /// Persiste uma Conta 
        /// </summary>
        /// <returns>Mensagem de Retorno e Objeto persistido</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Conta bill)
        {
            return PostWithRabbitMQ(
                bill,
                _service.Insert,
                async (_) =>
                {
                    await _rabbitMqPublisher.PublishCreatedAsync(bill);
                }
            );
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
