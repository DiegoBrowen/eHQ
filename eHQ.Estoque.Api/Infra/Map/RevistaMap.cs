using eHQ.Estoque.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHQ.Estoque.Api.Infra.Map
{
    public class RevistaMap : IEntityTypeConfiguration<Revista>
    {
        public void Configure(EntityTypeBuilder<Revista> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo)
                   .IsRequired();

            builder.Property(x => x.Ano)
                   .IsRequired();
        }
    }
}
