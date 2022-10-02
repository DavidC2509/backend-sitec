using CoreCommand.Repository;
using CoreDomain.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCommand
{
    /// <summary>
    /// Clase que extiende métodos
    /// </summary>
    public static class Service
    {
        /// <summary>
        /// Se encarga de regitrar el repositorio para gestionar ABM de los clasificador que hereda de BaseClassifierModel e implementa IAggreggateRoot
        /// </summary>
        /// <paramref name="services">Instancia a extender</paramref>
        /// <typeparam name="TServiceContext">Tipo de DbContext del proyecto</typeparam>
        public static void RegisterClassiffierRepository<TServiceContext>(this IServiceCollection services)
            where TServiceContext : DbContext, IUnitOfWork
        {
            services.AddScoped<IClassiffierRepository, GenericClassiffierRepository<TServiceContext>>();
        }

       
    }
}
