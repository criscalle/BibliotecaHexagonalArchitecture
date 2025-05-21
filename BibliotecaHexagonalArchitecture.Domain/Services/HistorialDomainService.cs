using BibliotecaHexagonalArchitecture.Domain.Entities;
using BibliotecaHexagonalArchitecture.Domain.Ports;

namespace BibliotecaHexagonalArchitecture.Domain.Services;

public class HistorialDomainService : IHistorialDomainService
{
    public string? ValidarPrestamo(Persona persona, Rol rol, MaterialAcademico material, int prestamosActivos)
    {
        if (persona == null) return "Persona no encontrada.";
        if (material == null) return "Material no encontrado.";
        if (prestamosActivos >= rol.LimitePrestamo)
            return "No puedes solicitar más materiales.";
        if (material.CantidadDisponible <= 0)
            return "No hay ejemplares disponibles.";
        return string.Empty;
    }

}
