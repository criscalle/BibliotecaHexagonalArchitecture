using BibliotecaHexagonalArchitecture.Application.Ports.Output;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaHexagonalArchitecture.Infrastructure.Adapters.Output.Persistence.Repositories;

public class TipoMaterialRepository : ITipoMaterialRepository
{
    private readonly ApplicationDbContext _context;

    public TipoMaterialRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExistsTipoMaterialAsync(int idMaterial)
    {
        return await _context.Tb_TipoMaterial.AnyAsync(m => m.Id == idMaterial);
    }
}
