using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaasService.Models;
using KaasService.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace KaasService.Repositories
{
    public class KaasRepository : IKaasRepository
    {
        private readonly KaaslandContext context;
        public KaasRepository(KaaslandContext context)
        {
            this.context = context;
        }

        public IQueryable<Kaas> FindAll()
        {
            return context.Kazen.AsNoTracking().AsQueryable();
        }

        public Kaas FindById(int id)
        {
            return context.Kazen.Find(id);
        }

        public IQueryable<Kaas> FindBySmaak(string smaak)
        {
            return context.Kazen.AsNoTracking()
            .Where(kaas => kaas.Smaak == smaak);
        }

        public void Update(Kaas kaas)
        {
            context.Kazen.Update(kaas);
            context.SaveChanges();
        }
    }
}
