using ProjetoDeliverIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using ProjetoDeliverIT.Data; // Altere para o namespace correto se necessário

namespace ProjetoDeliverIT.Repositories
{
    public class ContaRepository : IContaRepository
    {
        private readonly AppDbContext _context;

        public ContaRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Insert(Conta bill)
        {
            _context.Contas.Add(bill);
        }

        public IEnumerable<Conta> GetAll()
        {
            return _context.Contas.ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
