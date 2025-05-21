using BibliotecaHexagonalArchitecture.Domain.Entities;

namespace BibliotecaHexagonalArchitecture.Application.Ports.Output;

public interface IPersonaRepository : IAsyncRepository<Persona>
{
    Task AddAsync(Persona persona);
    Task<bool> ExistsPersonaByIdAsync(int id);
    Task<Persona> GetPersonaById(int id);
    Task<Persona> GetPersonaWithRolByIdAsync(int id);
}
