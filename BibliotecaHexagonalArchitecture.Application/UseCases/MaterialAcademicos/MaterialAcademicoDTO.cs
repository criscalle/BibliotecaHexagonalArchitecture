namespace BibliotecaHexagonalArchitecture.Application.UseCases.MaterialAcademicos;

public class MaterialAcademicoDTO
{
    public int Id { get; set; }
    public int IdTipoMaterial { get; set; }
    public string? Titulo { get; set; }
    public int CantidaRegistrada { get; set; }
    public int CantidadDisponible { get; set; }
}
