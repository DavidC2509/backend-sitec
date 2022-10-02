using CoreQuery;
using Data.Query.Repository;
using Microsoft.Extensions.DependencyInjection;
using Services.Query.Product;
using Services.Query.Warehouse;
using Services.Query.WarehouseProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Query
{
    public static class Service
    {
        public static void RegisterDataQuery(this IServiceCollection services, string connectionString)
        {
           



            services.AddScoped<IProductQueryRepository>(x => new ProductQueryRepository(connectionString));
            services.AddScoped<IWarehouseQueryRepository>(x => new WarehouseQueryRepository(connectionString));
            services.AddScoped<IWarehouseProductQueryRepository>(x => new WarehouseProductQueryRepository(connectionString));

        }
    }
}