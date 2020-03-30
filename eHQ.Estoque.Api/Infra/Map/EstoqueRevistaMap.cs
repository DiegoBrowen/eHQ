using eHQ.Estoque.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHQ.Estoque.Api.Infra.Map
{
    public class EstoqueRevistaMap : IEntityTypeConfiguration<EstoqueRevista>
    {
        public void Configure(EntityTypeBuilder<EstoqueRevista> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantidade)
                   .IsRequired();

            builder.Property(x => x.IdRevista)
                   .IsRequired(); ;
        }
    }
}
