using BibliotecaHexagonalArchitecture.Domain.Entities.Common;

namespace BibliotecaHexagonalArchitecture.Application.Ports.Output;

public interface IUnitOfWork : IDisposable
{
    IPersonaRepository PersonaRepository { get; }
    IHistorialRepository HistorialRepository { get; }
    IMaterialAcademicoRepository MaterialAcademicoRepository { get; }

    IRolRepository RolRepository { get; }
    IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;

    Task<int> Complete();
}
