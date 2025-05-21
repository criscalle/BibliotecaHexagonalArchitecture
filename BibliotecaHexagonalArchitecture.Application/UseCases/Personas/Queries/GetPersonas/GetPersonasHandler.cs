using AutoMapper;
using BibliotecaHexagonalArchitecture.Application.Ports.Output;
using BibliotecaHexagonalArchitecture.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;


namespace BibliotecaHexagonalArchitecture.Application.UseCases.Personas.Queries.GetPersonas;

public class GetPersonasHandler : IRequestHandler<GetPersonas, List<PersonaDTO>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<GetPersonasHandler> _logger;

    public GetPersonasHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetPersonasHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<PersonaDTO>> Handle(GetPersonas request, CancellationToken cancellationToken)
    {
        var personas = await _unitOfWork.Repository<Persona>().GetAllAsync();

        return _mapper.Map<List<PersonaDTO>>(personas);
    }
}
