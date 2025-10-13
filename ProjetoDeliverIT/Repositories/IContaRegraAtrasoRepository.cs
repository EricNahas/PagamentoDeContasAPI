using ProjetoDeliverIT.Models;

namespace ProjetoDeliverIT.Repositories
{
    public interface IContaRegraAtrasoRepository
    {
        IEnumerable<ContaRegraAtraso> GetAll();
        ContaRegraAtraso? GetByDias(int diasAtraso);
    }
}
