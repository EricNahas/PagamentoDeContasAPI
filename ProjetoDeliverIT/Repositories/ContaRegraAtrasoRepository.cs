using ProjetoDeliverIT.Data;
using ProjetoDeliverIT.Models;

namespace ProjetoDeliverIT.Repositories
{
    public class ContaRegraAtrasoRepository : IContaRegraAtrasoRepository
    {
        private readonly AppDbContext _context;
        public ContaRegraAtrasoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ContaRegraAtraso> GetAll() => _context.ContaRegraAtrasos.ToList();

        public ContaRegraAtraso? GetByDias(int diasAtraso)
        {
            return _context.ContaRegraAtrasos
                .FirstOrDefault(r => diasAtraso >= r.DiasMinimo && (diasAtraso <= r.DiasMaximo || r.DiasMaximo == null));
        }
    }
}
