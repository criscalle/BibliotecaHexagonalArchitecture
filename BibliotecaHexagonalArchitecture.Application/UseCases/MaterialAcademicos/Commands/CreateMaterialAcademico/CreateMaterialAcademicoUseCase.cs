using BibliotecaHexagonalArchitecture.Application.Ports.Output;
using BibliotecaHexagonalArchitecture.Domain.Entities;
using BibliotecaHexagonalArchitecture.Domain;
using BibliotecaHexagonalArchitecture.Domain.Ports;

namespace BibliotecaHexagonalArchitecture.Application.UseCases.MaterialAcademicos.Commands.CreateMaterialAcademico;

public class CreateMaterialAcademicoUseCase
{
    private readonly IMaterialAcademicoDomainService _materialAcademicoDomainService;
    private readonly IMaterialAcademicoRepository _materialAcademicoRepository;
    private readonly ITipoMaterialRepository _tipoMaterialRepository;

    public CreateMaterialAcademicoUseCase(IMaterialAcademicoDomainService materialAcademicoDomainService, IMaterialAcademicoRepository materialacademicoRepository, ITipoMaterialRepository tipoMaterialRepository)
    {
        _materialAcademicoDomainService = materialAcademicoDomainService;
        _materialAcademicoRepository = materialacademicoRepository;
        _tipoMaterialRepository = tipoMaterialRepository;
    }

    public async Task ExecuteAsync(MaterialAcademicoDTO request)
    {
        var material = new MaterialAcademico
        {
            Id = request.Id,
            IdTipoMaterial = request.IdTipoMaterial,
            CantidadDisponible = request.CantidadDisponible,
            CantidaRegistrada = request.CantidaRegistrada,
        };

        var contexto = new MaterialCreacionContext
        {
            TipoMaterialExiste = await _tipoMaterialRepository.ExistsTipoMaterialAsync(request.IdTipoMaterial),
        };

        await _materialAcademicoDomainService.ValidarCrearMaterialAsync(material, contexto);
        await _materialAcademicoRepository.AddAsync(material);
    }

}
