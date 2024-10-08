using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonService.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonService.DataAccess.Configuration;

public class PersonConfiguration : IEntityTypeConfiguration<PersonDb>
{
    public void Configure(EntityTypeBuilder<PersonDb> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd().IsRequired();
        builder.HasIndex(p => p.Id).IsUnique();

        builder.Property(p => p.Name).IsRequired();
    }
}
