using MediatR;

namespace BibliotecaHexagonalArchitecture.Application.UseCases.Personas.Commands.CreatePersona;

public class CreatePersonaCommand : IRequest<string>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public int IdRol { get; set; }
}
