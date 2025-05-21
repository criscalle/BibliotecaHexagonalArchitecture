using BibliotecaHexagonalArchitecture.Domain.Entities;

namespace BibliotecaHexagonalArchitecture.Application.Ports.Output;

public interface IPersonaRepository : IAsyncRepository<Persona>
{
    Task<bool> ExistsPersonaByIdAsync(int id);
}
