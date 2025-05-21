using BibliotecaHexagonalArchitecture.Application.Ports.Output;
using BibliotecaHexagonalArchitecture.Infrastructure.Adapters.Output.Persistence;
using BibliotecaHexagonalArchitecture.Infrastructure.Adapters.Output.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BibliotecaHexagonalArchitecture.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
        );

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

        services.AddScoped<IPersonaRepository, PersonaRepository>();
        services.AddScoped<IHistorialRepository, HistorialRepository>();
        services.AddScoped<IMaterialAcademicoRepository, MaterialAcademicoRepository>();
        services.AddScoped<IRolRepository, RolRepository>();
        services.AddScoped<ITipoMaterialRepository, TipoMaterialRepository>();

        return services;
    }
}
