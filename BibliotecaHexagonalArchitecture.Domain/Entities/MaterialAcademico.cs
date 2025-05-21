using BibliotecaHexagonalArchitecture.Domain.Entities.Common;

namespace BibliotecaHexagonalArchitecture.Domain.Entities;

public class MaterialAcademico : BaseDomainModel
{
    public int IdTipoMaterial { get; set; }
    public string? Titulo { get; set; }
    public int CantidaRegistrada { get; set; }
    public int CantidadDisponible { get; set; }

}
