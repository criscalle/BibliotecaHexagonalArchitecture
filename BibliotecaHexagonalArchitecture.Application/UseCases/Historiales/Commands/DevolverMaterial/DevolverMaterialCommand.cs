using MediatR;

namespace BibliotecaHexagonalArchitecture.Application.UseCases.Historiales.Commands.DevolverMaterial;

public class DevolverMaterialCommand : IRequest<string>
{
    public int PersonaId { get; set; }
    public int MaterialId { get; set; }

    public DevolverMaterialCommand(int personaId, int materialId)
    {
        PersonaId = personaId;
        MaterialId = materialId;
    }
}
