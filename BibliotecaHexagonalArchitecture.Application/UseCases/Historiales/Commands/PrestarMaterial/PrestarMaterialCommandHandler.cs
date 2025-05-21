using BibliotecaHexagonalArchitecture.Application.Ports.Input;
using MediatR;

namespace BibliotecaHexagonalArchitecture.Application.UseCases.Historiales.Commands.PrestarMaterial;

public class PrestarMaterialCommandHandler : IRequestHandler<PrestarMaterialCommand, string>
{
    private readonly IRegistrarPrestamoUseCase _registrarPrestamoUseCase;

    public PrestarMaterialCommandHandler(IRegistrarPrestamoUseCase registrarPrestamoUseCase)
    {
        _registrarPrestamoUseCase = registrarPrestamoUseCase;
    }

    public async Task<string> Handle(PrestarMaterialCommand request, CancellationToken cancellationToken)
    {
        return await _registrarPrestamoUseCase.PrestarMaterialAsync(request.PersonaId, request.MaterialId);
    }
}
