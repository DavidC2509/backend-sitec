
using CoreDomain.Domain;
using CoreDomain.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCommand.Repository
{
    /// <summary>
    /// Clase que implementa un repositorio para los clasificadores genéricos
    /// </summary>
    /// <typeparam name="TServiceContext">Tipo del DbContext del proyecto</typeparam>
    public class GenericClassiffierRepository<TServiceContext> : IClassiffierRepository
            where TServiceContext : DbContext, IUnitOfWork
    {
        /// <summary>
        /// Referencia al contexto de ejecución de EF
        /// </summary>
        protected readonly TServiceContext _context;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="context"></param>
        public GenericClassiffierRepository(TServiceContext context)
        {
            _context = context;
        }

        /// <summary>
        /// DataSet de la entidad Root
        /// </summary>
        protected DbSet<TClassiffier> DataSet<TClassiffier>() where TClassiffier : BaseNotMappedModel, IAggregateRoot
        {
            return _context.Set<TClassiffier>();
        }

        /// <summary>
        /// Objeto que implementa el patron de unidad de trabajo
        /// </summary>
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        /// <summary>
        /// Añade una entidad a la unidad de trabajo.
        /// </summary>
        /// <param name="item">Item a añadir</param>
        /// <returns>Retorna la entidad añadida</returns>
        public TClassiffier Add<TClassiffier>(TClassiffier item) where TClassiffier : BaseNotMappedModel, IAggregateRoot
        {
            if (item.IsTransient())
            {
                return DataSet<TClassiffier>()
                    .Add(item)
                    .Entity;
            }
            else
            {
                return item;
            }
        }

        /// <summary>
        /// Elimina una entidad a la unidad de trabajo.
        /// </summary>
        /// <param name="item">Item a actualizar</param>
        /// <returns>Retorna la entidad añadida</returns>
        public void Delete<TClassiffier>(TClassiffier item) where TClassiffier : BaseNotMappedModel, IAggregateRoot
        {
            DataSet<TClassiffier>().Remove(item);
        }

        /// <summary>
        /// Actualiza una entidad a la unidad de trabajo.
        /// </summary>
        /// <param name="item">Item a actualizar</param>
        /// <returns>Retorna la entidad añadida</returns>
        public TClassiffier Update<TClassiffier>(TClassiffier item) where TClassiffier : BaseNotMappedModel, IAggregateRoot
        {
            return DataSet<TClassiffier>()
                    .Update(item)
                    .Entity;
        }

        /// <summary>
        /// Busca un clasificador basado en el ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TClassiffier> FindByIdAsync<TClassiffier>(int id) where TClassiffier : BaseNotMappedModel, IAggregateRoot
        {
            var item = await DataSet<TClassiffier>()
                .Where(b => b.Id == id)
                .SingleOrDefaultAsync();

            return item;
        }

        /// <summary>
        /// Busca un clasificador con el mismo nombre que el parámetro dado
        /// </summary>
        /// <param name="description">Nombre del clasificador a buscar</param>
        /// <returns></returns>
        public IEnumerable<IBaseClassifier> FindByName<TClassiffier>(string description) where TClassiffier : BaseNotMappedModel, IAggregateRoot, IBaseClassifier
        {
            var item = DataSet<TClassiffier>().Where(r => r.Name == description).AsNoTracking().ToList();

            return item;
        }
    }
}
