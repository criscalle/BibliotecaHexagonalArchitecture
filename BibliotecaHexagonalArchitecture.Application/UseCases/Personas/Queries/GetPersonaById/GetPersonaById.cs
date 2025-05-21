using MediatR;

namespace BibliotecaHexagonalArchitecture.Application.UseCases.Personas.Queries.GetPersonaById;

public class GetPersonaById : IRequest<PersonaDTO>
{
    public int Id { get; set; }

    public GetPersonaById(int id)
    {
        Id = id;
    }
}
