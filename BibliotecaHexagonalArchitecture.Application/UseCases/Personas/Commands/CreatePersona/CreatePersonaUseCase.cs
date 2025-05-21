using BibliotecaHexagonalArchitecture.Application.Ports.Output;
using BibliotecaHexagonalArchitecture.Domain;
using BibliotecaHexagonalArchitecture.Domain.Entities;
using BibliotecaHexagonalArchitecture.Domain.Ports;

namespace BibliotecaHexagonalArchitecture.Application.UseCases.Personas.Commands.CreatePersona;

public class CreatePersonaUseCase
{
    private readonly IPersonaRepository _personaRepository;
    private readonly IRolRepository _rolRepository;
    private readonly IPersonaDomainService _personaDomainService;

    public CreatePersonaUseCase(IPersonaRepository personaRepository, IRolRepository rolRepository, IPersonaDomainService personaDomainService)
    {
        _personaRepository = personaRepository;
        _rolRepository = rolRepository;
        _personaDomainService = personaDomainService;
    }

    public async Task ExecuteAsync(PersonaDTO request)
    {
        var persona = new Persona
        {
            Id = request.Id,
            Nombre = request.Nombre,
            Apellido = request.Apellido,
            IdRol = request.IdRol
        };

        var contexto = new PersonaCreacionContext
        {
            PersonaYaExiste = await _personaRepository.ExistsPersonaByIdAsync(request.Id),
            RolExiste = await _rolRepository.ExistsRolAsync(request.IdRol)
        };

        await _personaDomainService.ValidarCrearPersonaAsync(persona, contexto);
        await _personaRepository.AddAsync(persona);
    }
}
