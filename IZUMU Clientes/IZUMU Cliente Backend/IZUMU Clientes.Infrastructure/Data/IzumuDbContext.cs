using IZUMU_Clientes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZUMU_Clientes.Infrastructure.Data
{
    public class IzumuDbContext : DbContext
    {
        public IzumuDbContext(DbContextOptions<IzumuDbContext> options)
       : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<TiposDocumento> TiposDocumento { get; set; }
        public DbSet<Plan> Planes { get; set; }
    }
}
