using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MP.ApiDotNet6.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.ApiDotNet6.Infra.Data.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("produto");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("idproduto").UseIdentityColumn();

            builder.Property(x => x.CodErp).HasColumnName("codeerp");

            builder.Property(x => x.Name).HasColumnName("nome");

            builder.Property(x => x.Price).HasColumnName("preco");

            builder.HasMany(x => x.Purchases).WithOne(p => p.Product).HasForeignKey(x => x.ProductId); // 1 Produto para N Compras
        }
    }
}
