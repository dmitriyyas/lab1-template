using PersonService.DataAccess.Models;
using PersonService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonService.DataAccess.Converters;

public static class PersonConverter
{
    public static Person? ConvertToDomain(PersonDb? personDb)
    {
        if (personDb is null)
            return null;

        return new Person(personDb.Id,
            personDb.Name,
            personDb.Age,
            personDb.Address,
            personDb.Work);
    }
}
