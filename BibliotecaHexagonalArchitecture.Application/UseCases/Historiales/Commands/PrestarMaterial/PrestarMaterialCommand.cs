using MediatR;

namespace BibliotecaHexagonalArchitecture.Application.UseCases.Historiales.Commands.PrestarMaterial;

public class PrestarMaterialCommand : IRequest<string>
{
    public int PersonaId { get; set; }
    public int MaterialId { get; set; }

    public PrestarMaterialCommand(int personaId, int materialId)
    {
        PersonaId = personaId;
        MaterialId = materialId;
    }
}
