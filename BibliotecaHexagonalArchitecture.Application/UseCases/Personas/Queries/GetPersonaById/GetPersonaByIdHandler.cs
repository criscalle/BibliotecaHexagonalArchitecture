using AutoMapper;
using BibliotecaHexagonalArchitecture.Application.Exceptions;
using BibliotecaHexagonalArchitecture.Application.Ports.Output;
using BibliotecaHexagonalArchitecture.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BibliotecaHexagonalArchitecture.Application.UseCases.Personas.Queries.GetPersonaById;

public class GetPersonaByIdHandler : IRequestHandler<GetPersonaById, PersonaDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<GetPersonaByIdHandler> _logger;

    public GetPersonaByIdHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetPersonaByIdHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<PersonaDTO> Handle(GetPersonaById request, CancellationToken cancellationToken)
    {
        var persona = await _unitOfWork.Repository<Persona>().GetByIdAsync(request.Id);

        if (persona == null)
        {
            _logger.LogWarning($"No se encontró la persona con ID {request.Id}");
            throw new NotFoundException(nameof(Persona), request.Id);
        }

        return _mapper.Map<PersonaDTO>(persona);
    }
}
