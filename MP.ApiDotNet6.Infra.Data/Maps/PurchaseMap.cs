using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MP.ApiDotNet6.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.ApiDotNet6.Infra.Data.Maps
{
    public class PurchaseMap : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("compra");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("idcompra").UseIdentityColumn();

            builder.Property(x => x.PersonId).HasColumnName("idpessoa");

            builder.Property(x => x.ProductId).HasColumnName("idproduto");

            builder.Property(x => x.Date).HasColumnName("datacompra");

            // Relacionamento N compras para uma Pessoa
            builder.HasOne(x => x.Person).WithMany(x => x.Purchases);

            //Relacionamento N compras para um Produto 
            builder.HasOne(x => x.Product).WithMany(x => x.Purchases);     
          
        }
    }
}
