using Microsoft.AspNetCore.Mvc;
using ProjetoDeliverIT.Enumerators;
using ProjetoDeliverIT.Models;
using ProjetoDeliverIT.Services;

namespace ProjetoDeliverIT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly IContaService _service;

        public ContaController(IContaService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Conta bill)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            RetornoAPI result = _service.Insert(bill);

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var bills = _service.GetAll();
            return Ok(bills);
        }
    }
}
