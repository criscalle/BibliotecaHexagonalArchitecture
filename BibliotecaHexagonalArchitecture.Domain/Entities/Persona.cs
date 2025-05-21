using BibliotecaHexagonalArchitecture.Domain.Entities.Common;

namespace BibliotecaHexagonalArchitecture.Domain.Entities;

public class Persona : BaseDomainModel
{
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public int IdRol { get; set; }

}
