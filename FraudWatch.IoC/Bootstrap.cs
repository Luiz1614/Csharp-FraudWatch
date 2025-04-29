using FraudWatch.Application.Factories;
using FraudWatch.Application.Factories.Interfaces;
using FraudWatch.Application.Mappings;
using FraudWatch.Application.Services;
using FraudWatch.Application.Services.Interfaces;
using FraudWatch.Infraestructure.Data.AppData;
using FraudWatch.Infraestructure.Data.Repositories;
using FraudWatch.Infraestructure.Data.Repositories.Interfaces;
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

        service.AddScoped<IDentistaFactory, DentistaFactory>();
        service.AddScoped<IAnalistaFactory, AnalistaFactory>();

        service.AddTransient<IViaCepApplicationService, ViaCepApplicationService>();

        service.AddTransient<ISentimentAnalysisApplicationService, SentimentAnalysisApplicationService>();

        service.AddAutoMapper(typeof(MapperProfile));
    }

}
