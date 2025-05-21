using BibliotecaHexagonalArchitecture.Domain.Entities;

namespace BibliotecaHexagonalArchitecture.Application.Ports.Output;

public interface IRolRepository
{
    Task<bool> ExistsRolAsync(int idRol);

    Task<Rol?> GetByIdAsync(int id);
}
