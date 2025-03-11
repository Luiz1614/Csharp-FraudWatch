using FraudWatch.Application.Interfaces;
using FraudWatch.Application.Mappings;
using FraudWatch.Application.Services;
using FraudWatch.Infraestructure.Data.AppData;
using FraudWatch.Infraestructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace revisao.IoC;

public class Bootstrap
{
    public static void Start(IServiceCollection service, IConfiguration configuration)
    {
        service.AddDbContext<ApplicationContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("Oracle");
            options.UseOracle(connectionString);
        });

        service.AddTransient<IDentistaRepository, DentistaRepository>();
        service.AddTransient<IAnalistaRepository, AnalistaRepository>();

        service.AddScoped<IDentistaApplicationService, DentistaApplicationService>();
        service.AddScoped<IAnalistaApplicationService, AnalistaApplicationService>();

        service.AddAutoMapper(typeof(MapperProfile));
    }

}
