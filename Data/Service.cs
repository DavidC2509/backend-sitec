using CoreCommand;
using Data.Command.Repository;
using Data.Database;
using Domain.Entities.ProductAggregate;
using Domain.Entities.WarehouseAggregate;
using Domain.Entities.WarehouseProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Command
{
    public static class Service
    {
        public static void RegisterClassifiers(this ModelBuilder modelBuilder)
        {
        }

        public static void RegisterDataCommand(this IServiceCollection services, string connectionString)
        {
            services.RegisterClassiffierRepository<DataBaseContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IWarehouseProductRepository, WarehouseProductRepository>();
            services.AddScoped<IWarehouseRepository, WarehouseRepository>();

        }

    }

}
