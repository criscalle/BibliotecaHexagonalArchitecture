using BibliotecaHexagonalArchitecture.Application.UseCases.Personas;
using BibliotecaHexagonalArchitecture.Application.UseCases.Personas.Commands.CreatePersona;
using BibliotecaHexagonalArchitecture.Application.UseCases.Personas.Commands.DeletePersona;
using BibliotecaHexagonalArchitecture.Application.UseCases.Personas.Commands.UpdatePersona;
using BibliotecaHexagonalArchitecture.Application.UseCases.Personas.Queries.GetPersonaById;
using BibliotecaHexagonalArchitecture.Application.UseCases.Personas.Queries.GetPersonas;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BibliotecaHexagonalArchitecture.API.Adapters.Input.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PersonaController : ControllerBase
{
    private readonly IMediator _mediator;

    public PersonaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(Name = "CreatePersona")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> CreatePersona([FromBody] CreatePersonaCommand command)
    {
        var mensaje = await _mediator.Send(command);
        return Ok(mensaje);
    }

    [HttpDelete("{id}", Name = "DeletePersona")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]

    public async Task<ActionResult> DeletePersona(int id)
    {
        var command = new DeletePersonaCommand()
        {
            Id = id
        };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut(Name = "UpdatePersona")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]

    public async Task<ActionResult> UpdatePersona([FromBody] UpdatePersonaCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpGet("{id}", Name = "GetPersonaById")]
    [ProducesResponseType(typeof(PersonaDTO), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<PersonaDTO>> GetPersona(int id)
    {
        var persona = await _mediator.Send(new GetPersonaById(id));
        return Ok(persona);
    }

    [HttpGet(Name = "GetPersonas")]
    [ProducesResponseType(typeof(List<PersonaDTO>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<List<PersonaDTO>>> GetPersonas()
    {
        var personas = await _mediator.Send(new GetPersonas());
        return Ok(personas);
    }
}
