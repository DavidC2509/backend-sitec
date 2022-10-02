
using CoreDomain.Domain;
using CoreDomain.Domain.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreCommand
{
    /// <summary>
    /// Clase base para los contextos de base de datos
    /// </summary>
    public abstract class BaseDbContext : DbContext, IUnitOfWork
    {
        /// <summary>
        /// Objeto mediadador para manejar eventos.
        /// </summary>
        protected readonly IMediator _mediator;
        /// <summary>
        /// Owner de la base de datos. Debe sobreescribirse en la clase base para devolver el owner deseado
        /// </summary>
        public abstract string Owner { get; }
        /// <summary>
        /// Prefijo a aplicar a todas las tablas. Debe sobreescribirse en la clase base para devolver el owner deseado
        /// </summary>
        public abstract string TablePrefix { get; }

        /// <summary>
        /// constructor sin parámetros.
        /// </summary>
        public BaseDbContext()
        {

        }

        /// <summary>
        /// Constructor para injección de dependencias
        /// </summary>
        /// <param name="session">Objeto con la info de sesión del usuario logueado</param>
        /// <param name="mediator">Objeto mediadador para manejar eventos.</param>
        public BaseDbContext(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Constructor para injección de dependencias
        /// </summary>
        /// <param name="options">Opciones de contexto</param>
        /// <param name="session">Objeto con la info de sesión del usuario logueado</param>
        /// <param name="mediator">Objeto mediadador para manejar eventos.</param>
        public BaseDbContext(DbContextOptions options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Saves all changes made in this context to the database.
        /// This method will automatically call Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.DetectChanges
        /// to discover any changes to entity instances before saving to the underlying database.
        /// This can be disabled via Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AutoDetectChangesEnabled.
        /// </summary>
        /// <returns>el número de entidades escritas en base de datos</returns>
        public override int SaveChanges()
        {
            int ReturnValue;
            OnBeforeSaving();
            _mediator.DispatchDomainEventsPreSaveAsync(this).GetAwaiter().GetResult();
            ReturnValue = base.SaveChanges();
            _mediator.DispatchDomainEventsPostSaveAsync(this).GetAwaiter().GetResult();

            return ReturnValue;
        }

        
        /// <summary>
        /// Método que se ejecuta antes de realizar el salvado de los cambios
        /// </summary>
        protected virtual void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            var now = DateTime.Now;
            foreach (var entry in entries)
            {
                if (entry.State != EntityState.Unchanged)
                {
                    if (entry.Entity is BaseMappedModel trackable)
                    {
                       
                        trackable.Computed = now;
                    }
                }
            }
        }

        /// <summary>
        /// Configura la base de datos a ser usada
        /// </summary>
        /// <param name="optionsBuilder">Builder de opciones</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var driver = Environment.GetEnvironmentVariable("DB_DRIVER");
                if (driver == "mysql")
                {
                    optionsBuilder.UseMySQL(Environment.GetEnvironmentVariable("DB_CONNECTION"));
                }
                else if (driver == "mssql")
                {
                    optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION"));
                }
            }
        }

        /// <summary>
        /// Se ejecuta al crear el modelo. Configura el owner y añade el prefijo a las tablas. Está sellada
        /// </summary>
        protected override sealed void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnPreModelCreating(modelBuilder);

            if (Environment.GetEnvironmentVariable("DB_DRIVER") == "mssql")
            {
                modelBuilder.HasDefaultSchema(Owner);
            }

            base.OnModelCreating(modelBuilder);
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(TablePrefix + entity.GetTableName());
            }

            OnPostModelCreating(modelBuilder);

        }

        /// <summary>
        /// Reemplazo del OnModelCreating, dado que se ha selleado dicho método. Todos los registrosd e entidades deberían hacerse aquí
        /// </summary>
        /// <param name="modelBuilder">Constructor de modelos</param>
        protected abstract void OnPreModelCreating(ModelBuilder modelBuilder);

        /// <summary>
        /// En caso que se desee ejecutar algo justo despues de haber terminado el OnModelCreating, sobreescribir este método
        /// </summary>
        /// <param name="modelBuilder">Constructor de modelos</param>
        protected virtual void OnPostModelCreating(ModelBuilder modelBuilder)
        {

        }


        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed
            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }
    }

}
