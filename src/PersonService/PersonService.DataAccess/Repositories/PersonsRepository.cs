using Microsoft.EntityFrameworkCore;
using PersonService.DataAccess.Converters;
using PersonService.DataAccess.Models;
using PersonService.Domain.Exceptions;
using PersonService.Domain.Interfaces.Repositories;
using PersonService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonService.DataAccess.Repositories;

public class PersonsRepository(PersonContext context) : IPersonsRepository
{
    private readonly PersonContext _context = context;

    public async Task<Person> CreatePerson(PersonCreate personCreate)
    {
        var personDb = new PersonDb(id: default,
            name: personCreate.Name,
            age: personCreate.Age,
            address: personCreate.Address,
            work: personCreate.Work);

        var result = await _context.Persons.AddAsync(personDb);
        await _context.SaveChangesAsync();

        return PersonConverter.ConvertToDomain(result.Entity)!;
    }

    public async Task DeletePerson(int id)
    {
        var person = await _context.Persons.FirstOrDefaultAsync(p => p.Id == id);
        if (person is null)
            throw new PersonNotFoundException($"Person with id = {id} wasn't found.");

        _context.Persons.Remove(person);
        await _context.SaveChangesAsync();
    }

    public async Task<Person?> GetPerson(int id)
    {
        var result = await _context.Persons.FirstOrDefaultAsync(p => p.Id == id);

        return PersonConverter.ConvertToDomain(result);
    }

    public async Task<List<Person>> GetPersons()
    {
        var result = await _context.Persons.ToListAsync();

        return result.ConvertAll(p => PersonConverter.ConvertToDomain(p)!);
    }

    public async Task<Person> UpdatePerson(int id, PersonUpdate personUpdate)
    {
        var person = await _context.Persons.FirstOrDefaultAsync(p => p.Id == id);
        if (person is null)
            throw new PersonNotFoundException($"Person with id = {id} wasn't found.");

        person.Name = personUpdate.Name;
        if (personUpdate.Age is not null)
            person.Age = personUpdate.Age;
        if (personUpdate.Address is not null)
            person.Address = personUpdate.Address;
        if (personUpdate.Work is not null)
            person.Work = personUpdate.Work;

        await _context.SaveChangesAsync();

        return PersonConverter.ConvertToDomain(person)!;
    }
}
