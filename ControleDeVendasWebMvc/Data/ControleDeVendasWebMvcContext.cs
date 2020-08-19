using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControleDeVendasWebMvc.Models;

namespace ControleDeVendasWebMvc.Data
{
    public class ControleDeVendasWebMvcContext : DbContext
    {
        public ControleDeVendasWebMvcContext (DbContextOptions<ControleDeVendasWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
