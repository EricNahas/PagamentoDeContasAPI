using ProjetoDeliverIT.Models;

namespace ProjetoDeliverIT.Services
{
    public interface IContaService
    {
        RetornoAPI Insert(Conta bill);
        IEnumerable<Conta> GetAll();

    }
}
