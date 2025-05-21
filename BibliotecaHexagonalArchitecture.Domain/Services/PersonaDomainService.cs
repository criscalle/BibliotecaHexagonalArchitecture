using BibliotecaHexagonalArchitecture.Domain.Entities;
using BibliotecaHexagonalArchitecture.Domain.Ports;

namespace BibliotecaHexagonalArchitecture.Domain.Services;

public class PersonaDomainService : IPersonaDomainService
{
    public Task ValidarCrearPersonaAsync(Persona persona, PersonaCreacionContext contexto)
    {
        if (contexto.PersonaYaExiste)
            throw new InvalidOperationException($"La persona con Id {persona.Id} ya existe.");

        if (!contexto.RolExiste)
            throw new InvalidOperationException($"El rol con Id {persona.IdRol} no existe.");

        return Task.CompletedTask;
    }

}
