using ProjetoDeliverIT.DTOs;
using ProjetoDeliverIT.Models;

namespace ProjetoDeliverIT.Services
{
    public interface IContaService
    {
        RetornoAPI Insert(Conta bill);
        IEnumerable<ContaDTO> GetAll();

    }
}
