using AutoMapper;

using MediatR;
using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

namespace Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //var serviceClientSettings = new RabbitConfigurationProvider().GetConfiguration();

            //services.AddSingleton<IRabbitConfigurationProvider, RabbitConfigurationProvider>();

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Todos los repositorys


            return services;
        }

    }
}
