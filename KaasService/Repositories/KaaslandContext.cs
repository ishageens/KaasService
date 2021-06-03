using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaasService.Models;
using Microsoft.EntityFrameworkCore;

namespace KaasService.Repositories
{
    public class KaaslandContext : DbContext
    {
        public KaaslandContext(DbContextOptions<KaaslandContext> options) : base(options) { }
        public DbSet<Kaas> Kazen { get; set; }
    }
}
