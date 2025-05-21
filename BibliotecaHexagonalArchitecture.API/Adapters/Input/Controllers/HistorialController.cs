using BibliotecaHexagonalArchitecture.Application.UseCases.Historiales.Commands.DevolverMaterial;
using BibliotecaHexagonalArchitecture.Application.UseCases.Historiales.Commands.PrestarMaterial;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaHexagonalArchitecture.API.Adapters.Input.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class HistorialController : ControllerBase
{
    private readonly IMediator _mediator;

    public HistorialController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("prestar")]
    public async Task<IActionResult> PrestarMaterial([FromBody] PrestarMaterialCommand command)
    {
        var resultado = await _mediator.Send(command);
        return Ok(resultado);
    }

    [HttpPost("devolver")]
    public async Task<IActionResult> DevolverMaterial([FromBody] DevolverMaterialCommand command)
    {
        var resultado = await _mediator.Send(command);
        return Ok(resultado);
    }
}
