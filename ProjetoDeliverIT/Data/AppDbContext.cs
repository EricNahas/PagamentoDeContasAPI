using Microsoft.EntityFrameworkCore;
using ProjetoDeliverIT.Models;
using System.Collections.Generic;

namespace ProjetoDeliverIT.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<ContaRegraAtraso> ContaRegraAtrasos { get; set; }

    }
}
