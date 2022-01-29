using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Descricao).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Preco).HasColumnType("decimal(18,2)");
            builder.Property(p => p.ImagemUrl).IsRequired();
            builder.HasOne(m => m.MarcaProduto).WithMany().HasForeignKey(p => p.MarcaProdutoId);
            builder.HasOne(t => t.TipoProduto).WithMany().HasForeignKey(p => p.TipoProdutoId);
        }
    }
}