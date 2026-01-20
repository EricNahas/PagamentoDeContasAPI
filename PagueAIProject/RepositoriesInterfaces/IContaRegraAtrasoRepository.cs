using ProjetoDeliverIT.Models;

namespace ProjetoDeliverIT.RepositoriesInterfaces
{
    public interface IContaRegraAtrasoRepository
    {
        IEnumerable<ContaRegraAtraso> GetAll();
        ContaRegraAtraso? GetByDias(int diasAtraso);
    }
}
