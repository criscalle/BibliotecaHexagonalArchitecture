using MediatR;

namespace BibliotecaHexagonalArchitecture.Application.UseCases.Personas.Commands.UpdatePersona;

public class UpdatePersonaCommand : IRequest
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public int IdRol { get; set; }
}
