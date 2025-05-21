using AutoMapper;
using BibliotecaHexagonalArchitecture.Application.UseCases.Historiales;
using BibliotecaHexagonalArchitecture.Application.UseCases.MaterialAcademicos;
using BibliotecaHexagonalArchitecture.Application.UseCases.MaterialAcademicos.Commands.CreateMaterialAcademico;
using BibliotecaHexagonalArchitecture.Application.UseCases.MaterialAcademicos.Commands.UpdateMaterialAcademico;
using BibliotecaHexagonalArchitecture.Application.UseCases.Personas;
using BibliotecaHexagonalArchitecture.Application.UseCases.Personas.Commands.CreatePersona;
using BibliotecaHexagonalArchitecture.Application.UseCases.Personas.Commands.UpdatePersona;
using BibliotecaHexagonalArchitecture.Domain.Entities;

namespace BibliotecaHexagonalArchitecture.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Persona, PersonaDTO>();
        CreateMap<CreatePersonaCommand, Persona>();
        CreateMap<UpdatePersonaCommand, Persona>();

        CreateMap<MaterialAcademico, MaterialAcademicoDTO>();
        CreateMap<CreateMaterialAcademicoCommand, MaterialAcademico>();
        CreateMap<UpdateMaterialAcademicoCommand, MaterialAcademico>();

        CreateMap<Historial, HistorialDTO>();

    }

}
