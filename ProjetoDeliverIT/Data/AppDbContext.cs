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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Carga inicial opcional (para ambiente de testes)
            modelBuilder.Entity<ContaRegraAtraso>().HasData(
                new ContaRegraAtraso { ID = 1, DiasMinimo = 0, DiasMaximo = 3, Multa = 0.02m, JurosDia = 0.1m },
                new ContaRegraAtraso { ID = 2, DiasMinimo = 4, DiasMaximo = 5, Multa = 0.03m, JurosDia = 0.2m },
                new ContaRegraAtraso { ID = 3, DiasMinimo = 6, DiasMaximo = null, Multa = 0.05m, JurosDia = 0.3m }
            );
        }

    }
}
