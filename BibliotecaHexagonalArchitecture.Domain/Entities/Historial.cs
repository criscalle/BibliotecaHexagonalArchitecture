using BibliotecaHexagonalArchitecture.Domain.Entities.Common;

namespace BibliotecaHexagonalArchitecture.Domain.Entities;

public class Historial : BaseDomainModel
{
    public int IdMaterial { get; set; }
    public int IdPersona { get; set; }

}
