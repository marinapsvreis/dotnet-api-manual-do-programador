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
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Pessoa");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("IDPESSOA").UseIdentityColumn();

            builder.Property(x => x.Name).HasColumnName("NOME");

            builder.Property(x => x.Document).HasColumnName("DOCUMENTO");

            builder.Property(x => x.Phone).HasColumnName("CELULAR");

            builder.HasMany(x => x.Purchases).WithOne(p => p.Person).HasForeignKey(x => x.PersonId);
        }
    }
}
