using BibliotecaHexagonalArchitecture.Domain.Entities;

namespace BibliotecaHexagonalArchitecture.Domain.Ports;

public interface IMaterialAcademicoDomainService
{
    Task ValidarCrearMaterialAsync(MaterialAcademico material, MaterialCreacionContext contexto);
}
