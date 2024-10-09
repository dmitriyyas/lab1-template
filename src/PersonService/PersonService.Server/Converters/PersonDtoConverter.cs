using PersonService.Domain.Models;
using PersonService.Server.Dto;

namespace PersonService.Server.Converters;

public static class PersonDtoConverter
{
    public static PersonResponse ConvertToDto(Person person)
    {
        return new PersonResponse(person.Id,
            person.Name,
            person.Age,
            person.Address,
            person.Work);
    }

    public static PersonCreate ConvertToCreateModel(PersonRequest request)
    {
        return new PersonCreate(request.Name,
            request.Age,
            request.Address,
            request.Work);
    }

    public static PersonUpdate ConvertToUpdateModel(PersonRequest request)
    {
        return new PersonUpdate(request.Name,
            request.Age,
            request.Address,
            request.Work);
    }
}
