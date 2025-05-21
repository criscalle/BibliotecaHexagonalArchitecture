using BibliotecaHexagonalArchitecture.Domain.Entities;

namespace BibliotecaHexagonalArchitecture.Domain.Ports;

public interface IHistorialDomainService
{
    string? ValidarPrestamo(Persona persona, Rol rol, MaterialAcademico material, int prestamosActivos);
}
