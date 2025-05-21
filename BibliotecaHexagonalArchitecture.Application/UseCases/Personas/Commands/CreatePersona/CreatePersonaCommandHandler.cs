using AutoMapper;
using BibliotecaHexagonalArchitecture.Application.Ports.Output;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BibliotecaHexagonalArchitecture.Application.UseCases.Personas.Commands.CreatePersona;

public class CreatePersonaCommandHandler : IRequestHandler<CreatePersonaCommand, string>
{
    private readonly ILogger<CreatePersonaCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly CreatePersonaUseCase _createPersonaUseCase;

    public CreatePersonaCommandHandler(ILogger<CreatePersonaCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork, CreatePersonaUseCase createPersonaUseCase)
    {
        _logger = logger;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _createPersonaUseCase = createPersonaUseCase;
    }

    public async Task<string> Handle(CreatePersonaCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var personaDto = new PersonaDTO
            {
                Id = request.Id,
                Nombre = request.Nombre,
                Apellido =  request.Apellido,
                IdRol = request.IdRol
            };

            await _createPersonaUseCase.ExecuteAsync(personaDto);

            _logger.LogInformation($"Persona creada correctamente con ID {request.Id}");
            return "Persona creada correctamente";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear persona");
            throw;
        }
    }
}
