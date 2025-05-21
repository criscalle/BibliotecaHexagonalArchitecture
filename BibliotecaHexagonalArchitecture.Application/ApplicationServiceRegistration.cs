using BibliotecaHexagonalArchitecture.Application.Ports.Input;
using BibliotecaHexagonalArchitecture.Application.UseCases.Historiales.Commands.DevolverMaterial;
using BibliotecaHexagonalArchitecture.Application.UseCases.Historiales.Commands.PrestarMaterial;
using BibliotecaHexagonalArchitecture.Application.UseCases.MaterialAcademicos.Commands.CreateMaterialAcademico;
using BibliotecaHexagonalArchitecture.Application.UseCases.Personas.Commands.CreatePersona;
using BibliotecaHexagonalArchitecture.Domain.Ports;
using BibliotecaHexagonalArchitecture.Domain.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace BibliotecaHexagonalArchitecture.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddScoped<IRegistrarDevolucionUseCase, RegistrarDevolucionUseCase>();
        services.AddScoped<IRegistrarPrestamoUseCase, RegistrarPrestamoUseCase>();
        services.AddScoped<IHistorialDomainService, HistorialDomainService>();
        services.AddScoped<IPersonaDomainService, PersonaDomainService>();
        services.AddScoped<IMaterialAcademicoDomainService, MaterialAcademicoDomainService>();
        services.AddTransient<CreatePersonaUseCase>();
        services.AddTransient<CreateMaterialAcademicoUseCase>();
        services.AddTransient<IMaterialAcademicoDomainService, MaterialAcademicoDomainService>();

        services.AddMediatR(c => c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        /*services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));*/

        return services;
    }
}
