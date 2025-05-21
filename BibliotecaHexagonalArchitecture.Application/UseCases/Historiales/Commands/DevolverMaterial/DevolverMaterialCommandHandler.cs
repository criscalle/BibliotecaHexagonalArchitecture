using BibliotecaHexagonalArchitecture.Application.Ports.Input;
using MediatR;

namespace BibliotecaHexagonalArchitecture.Application.UseCases.Historiales.Commands.DevolverMaterial;

public class DevolverMaterialCommandHandler : IRequestHandler<DevolverMaterialCommand, string>
{
    private readonly IRegistrarDevolucionUseCase _registrarDevolucionUseCase;

    public DevolverMaterialCommandHandler(IRegistrarDevolucionUseCase registrarDevolucionUseCase)
    {
        _registrarDevolucionUseCase = registrarDevolucionUseCase;
    }

    public async Task<string> Handle(DevolverMaterialCommand request, CancellationToken cancellationToken)
    {
        return await _registrarDevolucionUseCase.DevolverMaterialAsync(request.PersonaId, request.MaterialId);
    }
}
