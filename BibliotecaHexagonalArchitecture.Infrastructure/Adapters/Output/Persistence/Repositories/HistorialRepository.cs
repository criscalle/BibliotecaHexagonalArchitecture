using BibliotecaHexagonalArchitecture.Application.Ports.Output;
using BibliotecaHexagonalArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaHexagonalArchitecture.Infrastructure.Adapters.Output.Persistence.Repositories;

public class HistorialRepository : RepositoryBase<Historial>, IHistorialRepository
{
    public HistorialRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Historial>> GetHistorialByIdMaterial(int id)
    {
        return await _context.Tb_Historial!.Where(v => v.IdMaterial == id).ToListAsync();
    }

    public async Task<IEnumerable<Historial>> GetHistorialByIdPersona(int id)
    {
        return await _context.Tb_Historial!.Where(v => v.IdPersona == id).ToListAsync();
    }

    public async Task<Historial> GetPrestamoActivo(int personaId, int materialId)
    {
        return await _context.Tb_Historial
           .Where(h => h.IdPersona == personaId && h.IdMaterial == materialId && h.LastModifiedDate == null)
           .FirstOrDefaultAsync();
    }

    public async Task<int> CountPrestamosActivos(int personaId)
    {
        return await _context.Tb_Historial
            .Where(h => h.IdPersona == personaId && h.LastModifiedDate == null)
            .CountAsync();
    }
}
