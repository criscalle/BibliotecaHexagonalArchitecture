using BibliotecaHexagonalArchitecture.Application.UseCases.MaterialAcademicos;
using BibliotecaHexagonalArchitecture.Application.UseCases.MaterialAcademicos.Commands.CreateMaterialAcademico;
using BibliotecaHexagonalArchitecture.Application.UseCases.MaterialAcademicos.Commands.DeleteMaterialAcademico;
using BibliotecaHexagonalArchitecture.Application.UseCases.MaterialAcademicos.Commands.UpdateMaterialAcademico;
using BibliotecaHexagonalArchitecture.Application.UseCases.MaterialAcademicos.Queries.GetMaterialAcademicoById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BibliotecaHexagonalArchitecture.API.Adapters.Input.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class MaterialAcademicoController : ControllerBase
{
    private readonly IMediator _mediator;

    public MaterialAcademicoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(Name = "CreateMaterialAcademico")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> CreateMaterialAcademico([FromBody] CreateMaterialAcademicoCommand command)
    {
        var mensaje = await _mediator.Send(command);
        return Ok(mensaje);
    }

    [HttpDelete("{id}", Name = "DeleteMaterialAcademico")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]

    public async Task<ActionResult> DeleteMaterialAcademico(int id)
    {
        var result = await _mediator.Send(new DeleteMaterialAcademicoCommand { Id = id });
        return Ok(result);
    }

    [HttpPut(Name = "UpdateMaterialAcademico")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]

    public async Task<ActionResult> UpdateMaterialAcademico([FromBody] UpdateMaterialAcademicoCommand command)
    {
        await _mediator.Send(command);
        return Ok("Material actualizado correctamente");
    }

    [HttpGet("{id}", Name = "GetMaterialAcademicoById")]
    [ProducesResponseType(typeof(MaterialAcademicoDTO), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<MaterialAcademicoDTO>> GetMaterialAcademico(int id)
    {
        var material = await _mediator.Send(new GetMaterialAcademicoById(id));
        return Ok(material);
    }
}
