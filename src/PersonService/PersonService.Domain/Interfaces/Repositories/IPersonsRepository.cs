using PersonService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonService.Domain.Interfaces.Repositories;

public interface IPersonsRepository
{
    Task<List<Person>> GetPersons();
    Task<Person?> GetPerson(int id);
    Task<Person> CreatePerson(PersonCreate personCreate);
    Task<Person> UpdatePerson(int id, PersonUpdate personUpdate);
    Task DeletePerson(int id);
}
