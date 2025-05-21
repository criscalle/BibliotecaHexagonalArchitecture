using MediatR;

namespace BibliotecaHexagonalArchitecture.Application.UseCases.MaterialAcademicos.Commands.DeleteMaterialAcademico;

public class DeleteMaterialAcademicoCommand : IRequest<string>
{
    public int Id { get; set; }
}
