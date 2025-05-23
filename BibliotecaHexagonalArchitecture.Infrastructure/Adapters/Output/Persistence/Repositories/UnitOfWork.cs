﻿using BibliotecaHexagonalArchitecture.Application.Ports.Output;
using BibliotecaHexagonalArchitecture.Domain.Entities.Common;
using System.Collections;

namespace BibliotecaHexagonalArchitecture.Infrastructure.Adapters.Output.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private Hashtable _repositories;
    private readonly ApplicationDbContext _context;

    private IPersonaRepository _personaRepository;
    private IHistorialRepository _historialRepository;
    private IMaterialAcademicoRepository _materialRepository;
    private IRolRepository _rolRepository;

    public IPersonaRepository PersonaRepository => _personaRepository ??= new PersonaRepository(_context);
    public IHistorialRepository HistorialRepository => _historialRepository ??= new HistorialRepository(_context);
    public IMaterialAcademicoRepository MaterialAcademicoRepository => _materialRepository ??= new MaterialAcademicoRepository(_context);

    public IRolRepository RolRepository => _rolRepository ??= new RolRepository(_context);
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public ApplicationDbContext DbContext => _context;

    public async Task<int> Complete()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
    {
        if (_repositories == null)
        {
            _repositories = new Hashtable();
        }

        var type = typeof(TEntity).Name;

        if (!_repositories.ContainsKey(type))
        {
            var repositoryType = typeof(RepositoryBase<>);
            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
            _repositories.Add(type, repositoryInstance);
        }

        return (IAsyncRepository<TEntity>)_repositories[type];
    }
}
