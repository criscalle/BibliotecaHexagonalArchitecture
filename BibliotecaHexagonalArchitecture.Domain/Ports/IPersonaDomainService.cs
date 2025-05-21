using BibliotecaHexagonalArchitecture.Domain.Entities;

namespace BibliotecaHexagonalArchitecture.Domain.Ports;

public interface IPersonaDomainService
{
    Task ValidarCrearPersonaAsync(Persona persona, PersonaCreacionContext contexto);

}
