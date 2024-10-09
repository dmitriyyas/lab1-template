using PersonService.Domain.Exceptions;
using PersonService.Domain.Interfaces.Repositories;
using PersonService.Domain.Interfaces.Services;
using PersonService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonService.Domain.Services;

public class PersonsService(IPersonsRepository personRepository) : IPersonsService
{
    private readonly IPersonsRepository _personRepository = personRepository;
    public async Task<Person> GetPerson(int id)
    {
        var person = await _personRepository.GetPerson(id);
        if (person is null)
            throw new PersonNotFoundException($"Person with id = {id} wasn't found.");

        return person;
    }

    public Task<List<Person>> GetPersons()
        => _personRepository.GetPersons();

    public Task<Person> CreatePerson(PersonCreate personCreate)
        => _personRepository.CreatePerson(personCreate);

    public Task<Person> UpdatePerson(int id, PersonUpdate personUpdate)
        => _personRepository.UpdatePerson(id, personUpdate);

    public Task DeletePerson(int id)
        => _personRepository.DeletePerson(id);
}
