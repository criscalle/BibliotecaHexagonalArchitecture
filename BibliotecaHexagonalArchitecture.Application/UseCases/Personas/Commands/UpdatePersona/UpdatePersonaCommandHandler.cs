using AutoMapper;
using BibliotecaHexagonalArchitecture.Application.Exceptions;
using BibliotecaHexagonalArchitecture.Application.Ports.Output;
using BibliotecaHexagonalArchitecture.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BibliotecaHexagonalArchitecture.Application.UseCases.Personas.Commands.UpdatePersona;

public class UpdatePersonaCommandHandler : IRequestHandler<UpdatePersonaCommand>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    private ILogger<UpdatePersonaCommandHandler> _logger;

    public UpdatePersonaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdatePersonaCommandHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task Handle(UpdatePersonaCommand request, CancellationToken cancellationToken)
    {

        var personaToUpdate = await _unitOfWork.PersonaRepository.GetByIdAsync(request.Id);

        if (personaToUpdate == null)
        {
            _logger.LogError($"No se encontro a la Persona id {request.Id}");
            throw new NotFoundException(nameof(Persona), request.Id);
        }

        _mapper.Map(request, personaToUpdate, typeof(UpdatePersonaCommand), typeof(Persona));


        _unitOfWork.PersonaRepository.UpdateEntity(personaToUpdate);
        await _unitOfWork.Complete();

        _logger.LogInformation($"La operacion fue exitosa actualizando a la Persona {request.Id}");

    }
}
