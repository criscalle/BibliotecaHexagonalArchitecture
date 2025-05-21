using AutoMapper;
using BibliotecaHexagonalArchitecture.Application.Exceptions;
using BibliotecaHexagonalArchitecture.Application.Ports.Output;
using BibliotecaHexagonalArchitecture.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BibliotecaHexagonalArchitecture.Application.UseCases.MaterialAcademicos.Commands.DeleteMaterialAcademico;

public class DeleteMaterialAcademicoCommandHandler : IRequestHandler<DeleteMaterialAcademicoCommand, string>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<DeleteMaterialAcademicoCommandHandler> _logger;

    public DeleteMaterialAcademicoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteMaterialAcademicoCommandHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<string> Handle(DeleteMaterialAcademicoCommand request, CancellationToken cancellationToken)
    {
        var materialToDelete = await _unitOfWork.MaterialAcademicoRepository.GetByIdAsync(request.Id);


        if (materialToDelete == null)
        {
            _logger.LogError($"{request.Id} El Material no existe en el sistema");
            throw new NotFoundException(nameof(MaterialAcademico), request.Id);
        }

        _unitOfWork.MaterialAcademicoRepository.DeleteEntity(materialToDelete);
        await _unitOfWork.Complete();

        _logger.LogInformation($"El {request.Id} fue eliminado con exito");
        return "Material Academico eliminado Correctamente";
    }
}
