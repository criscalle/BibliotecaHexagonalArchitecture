using MediatR;

namespace BibliotecaHexagonalArchitecture.Application.UseCases.MaterialAcademicos.Queries.GetMaterialAcademicoById;

public class GetMaterialAcademicoById : IRequest<MaterialAcademicoDTO>
{
    public int Id { get; set; }

    public GetMaterialAcademicoById(int id)
    {
        Id = id;
    }
}
