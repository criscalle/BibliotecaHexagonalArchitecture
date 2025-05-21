using AutoMapper;
using BibliotecaHexagonalArchitecture.Application.Ports.Output;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BibliotecaHexagonalArchitecture.Application.UseCases.MaterialAcademicos.Commands.CreateMaterialAcademico;

public class CreateMaterialAcademicoCommandHandler : IRequestHandler<CreateMaterialAcademicoCommand, string>
{
    private readonly ILogger<CreateMaterialAcademicoCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly CreateMaterialAcademicoUseCase _useCase;

    public CreateMaterialAcademicoCommandHandler(ILogger<CreateMaterialAcademicoCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork, CreateMaterialAcademicoUseCase useCase)
    {
        _logger = logger;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _useCase = useCase;
    }

    public async Task<string> Handle(CreateMaterialAcademicoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var Material = new MaterialAcademicoDTO
            {
                Id = request.Id,
                IdTipoMaterial = request.IdTipoMaterial,
                CantidadDisponible = request.CantidadDisponible,
                CantidaRegistrada = request.CantidaRegistrada
            };

            await _useCase.ExecuteAsync(Material);

            _logger.LogInformation($"Material creado correctamente con ID {request.Id}");
            return "Material Academico creado correctamente";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear el Material Academico");
            throw;
        }
    }
}
