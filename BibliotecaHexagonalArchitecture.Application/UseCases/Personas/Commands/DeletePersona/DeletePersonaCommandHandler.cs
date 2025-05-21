using AutoMapper;
using BibliotecaHexagonalArchitecture.Application.Exceptions;
using BibliotecaHexagonalArchitecture.Application.Ports.Output;
using BibliotecaHexagonalArchitecture.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BibliotecaHexagonalArchitecture.Application.UseCases.Personas.Commands.DeletePersona;

public class DeletePersonaCommandHandler : IRequestHandler<DeletePersonaCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<DeletePersonaCommandHandler> _logger;

    public DeletePersonaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeletePersonaCommandHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task Handle(DeletePersonaCommand request, CancellationToken cancellationToken)
    {
        var directorToDelete = await _unitOfWork.PersonaRepository.GetByIdAsync(request.Id);


        if (directorToDelete == null)
        {
            _logger.LogError($"{request.Id} La persona no existe en el sistema");
            throw new NotFoundException(nameof(Persona), request.Id);
        }

        _unitOfWork.PersonaRepository.DeleteEntity(directorToDelete);
        await _unitOfWork.Complete();

        _logger.LogInformation($"El {request.Id} fue eliminado con exito");
    }
}
