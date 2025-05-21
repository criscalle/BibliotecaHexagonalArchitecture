using BibliotecaHexagonalArchitecture.Application.Ports.Input;
using BibliotecaHexagonalArchitecture.Application.Ports.Output;
using BibliotecaHexagonalArchitecture.Domain.Ports;
namespace BibliotecaHexagonalArchitecture.Application.UseCases.Historiales.Commands.DevolverMaterial;

public class RegistrarDevolucionUseCase : IRegistrarDevolucionUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHistorialDomainService _historialDomainService;

    public RegistrarDevolucionUseCase(IUnitOfWork unitOfWork, IHistorialDomainService historialDomainService)
    {
        _unitOfWork = unitOfWork;
        _historialDomainService = historialDomainService;
    }

    public async Task<string> DevolverMaterialAsync(int personaId, int materialId)
    {
        var historial = await _unitOfWork.HistorialRepository.GetPrestamoActivo(personaId, materialId);

        if (historial == null)
        {
            return "No se encontró un préstamo activo.";
        }

        historial.LastModifiedDate = DateTime.UtcNow;

        var material = await _unitOfWork.MaterialAcademicoRepository.GetByIdAsync(materialId);
        if (material != null)
        {
            material.CantidadDisponible++;
        }

        await _unitOfWork.Complete();
        return "Material devuelto correctamente.";
    }
}
