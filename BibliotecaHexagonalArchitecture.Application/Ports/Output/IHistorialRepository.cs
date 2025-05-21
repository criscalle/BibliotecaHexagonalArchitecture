using BibliotecaHexagonalArchitecture.Domain.Entities;

namespace BibliotecaHexagonalArchitecture.Application.Ports.Output;

public interface IHistorialRepository : IAsyncRepository<Historial>
{
    Task<IEnumerable<Historial>> GetHistorialByIdPersona(int id);

    Task<IEnumerable<Historial>> GetHistorialByIdMaterial(int id);
    Task<int> CountPrestamosActivos(int personaId);
    Task<Historial> GetPrestamoActivo(int personaId, int materialId);
}
