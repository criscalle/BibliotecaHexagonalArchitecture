using MediatR;

namespace BibliotecaHexagonalArchitecture.Application.UseCases.Personas.Commands.DeletePersona;

public class DeletePersonaCommand : IRequest
{
    public int Id { get; set; }
}
