using eHQ.Produto.Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHQ.Produto.Api.Data.Map
{
    public class RevistaMap : IEntityTypeConfiguration<Revista>
    {
        public void Configure(EntityTypeBuilder<Revista> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(x => x.Autor)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(x => x.Ano)
                   .IsRequired();

            builder.Property(x => x.Descricao)
                   .HasMaxLength(1000)
                   .IsRequired();

            builder.Property(x => x.Descricao)
                   .HasMaxLength(200)
                   .IsRequired();
        }
    }
}
