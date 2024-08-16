using System;
using lrms.Infra.Data.Context;
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

        return services;
    }
}
