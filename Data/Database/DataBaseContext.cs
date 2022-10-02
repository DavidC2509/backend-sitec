using CoreCommand;
using Data.Command.Configurations;
using Data.Configurations;
using Domain.Entities;
using Domain.Entities.ProductAggregate;

using Domain.Entities.WarehouseAggregate;
using Domain.Entities.WarehouseProductAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Database
{
    public class DataBaseContext : BaseDbContext
    {
        public DataBaseContext()
        {
        }

        public DataBaseContext(IMediator mediator) : base( mediator)
        {
        }

        public DataBaseContext(DbContextOptions<DataBaseContext> options, IMediator mediator)
            : base(options, mediator)
        {
        }

        public override string Owner => "fassil";
        public override string TablePrefix => "fassil_";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;Database=Fassil_Test;User ID=root;Password=David#2509");
            }
        }
        /// <summary>
        /// Todo los registros de las entidades se hacen aqui con sus configuraciones
        /// </summary>
        /// <param name="modelBuilder">Constructor de modelos</param>
        protected override void OnPreModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new ProductConfigurations());
            modelBuilder.ApplyConfiguration(new WarehouseConfigurations());
            modelBuilder.ApplyConfiguration(new Warehouse_ProductConfigurations());
            modelBuilder.ApplyConfiguration(new WarehouseProductSaleConfigurations());

            
        }

    }
}
