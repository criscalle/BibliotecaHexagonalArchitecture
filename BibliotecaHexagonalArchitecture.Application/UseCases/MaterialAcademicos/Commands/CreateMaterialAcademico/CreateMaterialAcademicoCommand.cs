using MediatR;

namespace BibliotecaHexagonalArchitecture.Application.UseCases.MaterialAcademicos.Commands.CreateMaterialAcademico;

public class CreateMaterialAcademicoCommand : IRequest<string>
{
    public int Id { get; set; }
    public int IdTipoMaterial { get; set; }
    public string? Titulo { get; set; }
    public int CantidaRegistrada { get; set; }
    public int CantidadDisponible { get; set; }
}
