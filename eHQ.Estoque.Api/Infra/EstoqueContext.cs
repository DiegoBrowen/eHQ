using eHQ.Estoque.Api.Infra.Map;
using eHQ.Estoque.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace eHQ.Estoque.Api.Infra
{
    public class EstoqueContext : DbContext
    {
        public EstoqueContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<EstoqueRevista> EstoqueRevistas { get; set; }
        public DbSet<Revista> Revistas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EstoqueRevistaMap());
            modelBuilder.ApplyConfiguration(new RevistaMap());
        }
    }
}
