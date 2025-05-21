using AutoMapper;
using BibliotecaHexagonalArchitecture.Application.Exceptions;
using BibliotecaHexagonalArchitecture.Application.Ports.Output;
using BibliotecaHexagonalArchitecture.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BibliotecaHexagonalArchitecture.Application.UseCases.MaterialAcademicos.Commands.UpdateMaterialAcademico;

public class UpdateMaterialAcademicoCommandHandler : IRequestHandler<UpdateMaterialAcademicoCommand>
{
    private readonly ILogger<UpdateMaterialAcademicoCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateMaterialAcademicoCommandHandler(ILogger<UpdateMaterialAcademicoCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(UpdateMaterialAcademicoCommand request, CancellationToken cancellationToken)
    {

        var materialToUpdate = await _unitOfWork.MaterialAcademicoRepository.GetByIdAsync(request.Id);

        if (materialToUpdate == null)
        {
            _logger.LogError($"No se encontro al Material id {request.Id}");
            throw new NotFoundException(nameof(MaterialAcademico), request.Id);
        }

        _mapper.Map(request, materialToUpdate, typeof(UpdateMaterialAcademicoCommand), typeof(MaterialAcademico));


        _unitOfWork.MaterialAcademicoRepository.UpdateEntity(materialToUpdate);
        await _unitOfWork.Complete();

        _logger.LogInformation($"La operacion fue exitosa actualizando al Material {request.Id}");
    }
}
