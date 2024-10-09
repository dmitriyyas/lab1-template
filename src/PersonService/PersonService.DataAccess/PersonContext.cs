using Microsoft.EntityFrameworkCore;
using PersonService.DataAccess.Configuration;
using PersonService.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonService.DataAccess;

public class PersonContext : DbContext
{
    public DbSet<PersonDb> Persons { get; set; }

    public PersonContext()
    {

    }

    public PersonContext(DbContextOptions<PersonContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new PersonConfiguration());
    }
}
