using BibliotecaHexagonalArchitecture.Application.Ports.Output;
using BibliotecaHexagonalArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaHexagonalArchitecture.Infrastructure.Adapters.Output.Persistence.Repositories;

public class PersonaRepository : RepositoryBase<Persona>, IPersonaRepository
{
    public PersonaRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    public async Task<bool> ExistsPersonaByIdAsync(int id)
    {
        return await _context.Tb_Persona.AnyAsync(p => p.Id == id);
    }

}
