using BibliotecaHexagonalArchitecture.Domain.Entities;
using BibliotecaHexagonalArchitecture.Domain.Ports;

namespace BibliotecaHexagonalArchitecture.Domain.Services;

public class MaterialAcademicoDomainService : IMaterialAcademicoDomainService
{
    public Task ValidarCrearMaterialAsync(MaterialAcademico material, MaterialCreacionContext contexto)
    {
        if (!contexto.TipoMaterialExiste)
            throw new InvalidOperationException($"El Tipo de Material con Id {material.IdTipoMaterial} no existe.");

        return Task.CompletedTask;
    }
}
