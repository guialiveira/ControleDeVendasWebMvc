﻿using System;
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

        public DbSet<ControleDeVendasWebMvc.Models.Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SellesRecord> SellesRecord { get; set; }
    }
}
