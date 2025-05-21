namespace BibliotecaHexagonalArchitecture.Application.Ports.Input;

public interface IRegistrarPrestamoUseCase
{
    Task<string> PrestarMaterialAsync(int personaId, int materialId);
}
