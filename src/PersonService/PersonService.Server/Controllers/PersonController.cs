using Microsoft.AspNetCore.Mvc;
using PersonService.Domain.Exceptions;
using PersonService.Domain.Interfaces.Services;
using PersonService.Server.Converters;
using PersonService.Server.Dto;

namespace PersonService.Server.Controllers;

[ApiController]
[Route("api/v1/persons")]
public class PersonController(IPersonsService personService) : ControllerBase
{
    private readonly IPersonsService _personService = personService;

    [HttpGet]
    public async Task<IActionResult> GetPersons()
    {
        try
        {
            var persons = await _personService.GetPersons();

            return Ok(persons.ConvertAll(p => PersonDtoConverter.ConvertToDto(p)));
        }
        catch (Exception ex)
        {
            var error = new ErrorResponse(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, error);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPerson([FromRoute] int id)
    {
        try
        {
            var person = await _personService.GetPerson(id);

            return Ok(PersonDtoConverter.ConvertToDto(person));
        }
        catch (PersonNotFoundException ex)
        {
            var error = new ErrorResponse(ex.Message);
            return NotFound(error);
        }
        catch (Exception ex)
        {
            var error = new ErrorResponse(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, error);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreatePerson([FromBody] PersonRequest request)
    {
        try
        {
            var personCreate = PersonDtoConverter.ConvertToCreateModel(request);
            var person = await _personService.CreatePerson(personCreate);

            return Created($"/api/v1/persons/{person.Id}", person);
        }
        catch (Exception ex)
        {
            var error = new ErrorResponse(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, error);
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdatePerson([FromRoute] int id, [FromBody] PersonRequest request)
    {
        try
        {
            var personUpdate = PersonDtoConverter.ConvertToUpdateModel(request);
            var person = await _personService.UpdatePerson(id, personUpdate);

            return Ok(PersonDtoConverter.ConvertToDto(person));
        }
        catch (PersonNotFoundException ex)
        {
            var error = new ErrorResponse(ex.Message);
            return NotFound(error);
        }
        catch (Exception ex)
        {
            var error = new ErrorResponse(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, error);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePerson([FromRoute] int id)
    {
        try
        {
            await _personService.DeletePerson(id);

            return NoContent();
        }
        catch (PersonNotFoundException ex)
        {
            var error = new ErrorResponse(ex.Message);
            return NotFound(error);
        }
        catch (Exception ex)
        {
            var error = new ErrorResponse(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, error);
        }
    }
}
