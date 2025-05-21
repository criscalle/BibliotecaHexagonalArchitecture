using MediatR;

namespace BibliotecaHexagonalArchitecture.Application.UseCases.MaterialAcademicos.Commands.UpdateMaterialAcademico;

public class UpdateMaterialAcademicoCommand : IRequest
{
    public int Id { get; set; }
    public int IdTipoMaterial { get; set; }
    public string? Titulo { get; set; }
    public int CantidaRegistrada { get; set; }
    public int CantidadDisponible { get; set; }
}
