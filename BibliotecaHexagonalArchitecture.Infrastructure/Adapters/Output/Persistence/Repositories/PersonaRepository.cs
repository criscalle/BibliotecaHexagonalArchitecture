using BibliotecaHexagonalArchitecture.Application.Ports.Output;
using BibliotecaHexagonalArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaHexagonalArchitecture.Infrastructure.Adapters.Output.Persistence.Repositories;

public class PersonaRepository : RepositoryBase<Persona>, IPersonaRepository
{
    public PersonaRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    public async Task<Persona> GetPersonaById(int id)
    {
        return await _context.Tb_Persona!.Where(v => v.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Persona> GetPersonaWithRolByIdAsync(int id)
    {
        var persona = await _context.Tb_Persona!
        .Where(p => p.Id == id)
        .Include(p => p.IdRol)
        .FirstOrDefaultAsync();

        return persona;
    }

    Task IPersonaRepository.AddAsync(Persona persona)
    {
        return AddAsync(persona);
    }

    public async Task<bool> ExistsPersonaByIdAsync(int id)
    {
        return await _context.Tb_Persona.AnyAsync(p => p.Id == id);
    }

}
