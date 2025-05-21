namespace BibliotecaHexagonalArchitecture.Application.Ports.Output;

public interface ITipoMaterialRepository
{
    Task<bool> ExistsTipoMaterialAsync(int idTipoMaterial);
}
