using Microsoft.EntityFrameworkCore;
using PersonService.DataAccess;
using PersonService.DataAccess.Models;
using PersonService.DataAccess.Repositories;
using PersonService.Domain.Exceptions;
using PersonService.Domain.Models;
using PersonService.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonService.UnitTests;

public class PersonsServiceUnitTests
{
    private (PersonsService, PersonContext) CreateServiceWithContext()
    {
        var builder = new DbContextOptionsBuilder<PersonContext>();
        builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

        var context = new PersonContext(builder.Options);
        var repo = new PersonsRepository(context);
        var service = new PersonsService(repo);

        return (service, context);
    }

    [Fact]
    public async void TestCreate()
    {
        var (service, _) = CreateServiceWithContext();
        var create = new PersonCreate("Ivan", 18, "addr", "work");
        var person = await service.CreatePerson(create);

        Assert.Equal(create.Name, person.Name);
        Assert.Equal(create.Age, person.Age);
        Assert.Equal(create.Address, person.Address);
        Assert.Equal(create.Work, person.Work);
    }

    [Fact]
    public async void TestGet()
    {
        var (service, context) = CreateServiceWithContext();

        var person = new PersonDb(default, "Ivan", 18, "addr", "work");
        var addedPerson = context.Persons.Add(person).Entity;
        context.SaveChanges();

        var result = await service.GetPerson(addedPerson.Id);

        Assert.Equal(result.Name, person.Name);
        Assert.Equal(result.Age, person.Age);
        Assert.Equal(result.Address, person.Address);
        Assert.Equal(result.Work, person.Work);
    }

    [Fact]
    public async void TestUpdate()
    {
        var (service, context) = CreateServiceWithContext();

        var person = new PersonDb(default, "Ivan", 18, "addr", "work");
        var addedPerson = context.Persons.Add(person).Entity;
        context.SaveChanges();

        var newAge = 20;
        var result = await service.UpdatePerson(addedPerson.Id, new PersonUpdate(addedPerson.Name, newAge, null, null));

        Assert.Equal(result.Name, person.Name);
        Assert.Equal(result.Age, newAge);
        Assert.Equal(result.Address, person.Address);
        Assert.Equal(result.Work, person.Work);
    }

    [Fact]
    public async void TestDelete()
    {
        var (service, context) = CreateServiceWithContext();

        var person = new PersonDb(default, "Ivan", 18, "addr", "work");
        var addedPerson = context.Persons.Add(person).Entity;
        context.SaveChanges();

        await service.DeletePerson(addedPerson.Id);

        Assert.Equal(0, context.Persons.Count());
    }
}
