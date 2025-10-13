using ProjetoDeliverIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using ProjetoDeliverIT.Data; 

namespace ProjetoDeliverIT.Repositories
{
    public interface IContaRepository
    {
        void Insert(Conta bill);
        IEnumerable<Conta> GetAll();
        void SaveChanges();
    }
}
