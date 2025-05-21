using BibliotecaHexagonalArchitecture.Application.Ports.Input;
using BibliotecaHexagonalArchitecture.Application.Ports.Output;
using BibliotecaHexagonalArchitecture.Domain.Entities;
using BibliotecaHexagonalArchitecture.Domain.Ports;

namespace BibliotecaHexagonalArchitecture.Application.UseCases.Historiales.Commands.PrestarMaterial;

public class RegistrarPrestamoUseCase : IRegistrarPrestamoUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHistorialDomainService _historialDomainService;

    public RegistrarPrestamoUseCase(IUnitOfWork unitOfWork, IHistorialDomainService historialDomainService)
    {
        _unitOfWork = unitOfWork;
        _historialDomainService = historialDomainService;
    }

    public async Task<string> PrestarMaterialAsync(int personaId, int materialId)
    {
        var persona = await _unitOfWork.PersonaRepository.GetByIdAsync(personaId);
        if (persona == null) return "Persona no encontrada.";

        var rol = await _unitOfWork.RolRepository.GetByIdAsync(persona.IdRol);
        if (rol == null) return "Rol no encontrado.";

        var material = await _unitOfWork.MaterialAcademicoRepository.GetByIdAsync(materialId);
        if (material == null) return "Material no encontrado.";

        int prestamosActivos = await _unitOfWork.HistorialRepository.CountPrestamosActivos(personaId);

        var validacion = _historialDomainService.ValidarPrestamo(persona, rol, material, prestamosActivos);
        if (!string.IsNullOrEmpty(validacion)) return validacion;

        var historial = new Historial
        {
            IdMaterial = materialId,
            IdPersona = personaId
        };

        await _unitOfWork.HistorialRepository.AddAsync(historial);
        material.CantidadDisponible--;

        await _unitOfWork.Complete();
        return "Préstamo registrado correctamente.";
    }
}
