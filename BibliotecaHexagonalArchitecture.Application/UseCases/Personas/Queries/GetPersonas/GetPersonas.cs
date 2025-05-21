using MediatR;

namespace BibliotecaHexagonalArchitecture.Application.UseCases.Personas.Queries.GetPersonas;

public class GetPersonas : IRequest<List<PersonaDTO>>
{
}
