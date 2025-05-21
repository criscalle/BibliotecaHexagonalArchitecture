using BibliotecaHexagonalArchitecture.Application.Ports.Output;
using BibliotecaHexagonalArchitecture.Domain.Entities;
using BibliotecaHexagonalArchitecture.Infrastructure.Adapters.Output.Persistence;

namespace BibliotecaHexagonalArchitecture.Infrastructure.Adapters.Output.Persistence.Repositories;

public class MaterialAcademicoRepository : RepositoryBase<MaterialAcademico>, IMaterialAcademicoRepository
{
    public MaterialAcademicoRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
