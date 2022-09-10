﻿using Microsoft.EntityFrameworkCore;
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
            builder.ToTable("pessoa");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("idpessoa").UseIdentityColumn();

            builder.Property(x => x.Name).HasColumnName("nome");

            builder.Property(x => x.Document).HasColumnName("documento");

            builder.Property(x => x.Phone).HasColumnName("celular");

            builder.HasMany(x => x.Purchases).WithOne(p => p.Person).HasForeignKey(x => x.PersonId);
        }
    }
}
