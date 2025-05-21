using BibliotecaHexagonalArchitecture.Application.Ports.Output;
using BibliotecaHexagonalArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaHexagonalArchitecture.Infrastructure.Adapters.Output.Persistence.Repositories;

public class RolRepository : IRolRepository
{
    private readonly ApplicationDbContext _context;

    public RolRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExistsRolAsync(int idRol)
    {
        return await _context.Tb_Rol.AnyAsync(r => r.Id == idRol);
    }

    public async Task<Rol?> GetByIdAsync(int id)
    {
        return await _context.Tb_Rol.FindAsync(id);
    }
}
