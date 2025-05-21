using AutoMapper;
using BibliotecaHexagonalArchitecture.Application.Exceptions;
using BibliotecaHexagonalArchitecture.Application.Ports.Output;
using BibliotecaHexagonalArchitecture.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BibliotecaHexagonalArchitecture.Application.UseCases.MaterialAcademicos.Queries.GetMaterialAcademicoById;

public class GetMaterialAcademicoByIdHandler : IRequestHandler<GetMaterialAcademicoById, MaterialAcademicoDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<GetMaterialAcademicoByIdHandler> _logger;

    public GetMaterialAcademicoByIdHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetMaterialAcademicoByIdHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<MaterialAcademicoDTO> Handle(GetMaterialAcademicoById request, CancellationToken cancellationToken)
    {
        var material = await _unitOfWork.Repository<MaterialAcademico>().GetByIdAsync(request.Id);

        if (material == null)
        {
            _logger.LogWarning($"No se encontró el Material con ID {request.Id}");
            throw new NotFoundException(nameof(MaterialAcademico), request.Id);
        }

        return _mapper.Map<MaterialAcademicoDTO>(material);
    }
}
