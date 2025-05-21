namespace BibliotecaHexagonalArchitecture.Application.Ports.Input;

public interface IRegistrarDevolucionUseCase
{
    Task<string> DevolverMaterialAsync(int personaId, int materialId);
}
