using System;
using lrms.Domain.Aggregates;
using lrms.Infra.Data.Context;
using lrms.Infra.Data.Entities;
using lrms.Infra.Data.Interfaces;
using lrms.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace lrms.Infra.Ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseMySql(configuration.GetConnectionString("MySQL"),
                             ServerVersion.AutoDetect(configuration.GetConnectionString("MySQL")),
                             options => options.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName));
        });

        services.AddScoped<IMapper<UserEntity, UserAggregate>, UserMapper>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
