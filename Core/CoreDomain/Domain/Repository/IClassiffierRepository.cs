using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreDomain.Domain.Repository
{
    /// <summary>
    /// Interfaz que representa un repositorio para los clasificadores genéricos
    /// </summary>
    /// <typeparam name="TClassiffier"></typeparam>
    public interface IClassiffierRepository
    {
        /// <summary>
        /// Objeto que implementa el patron de unidad de trabajo
        /// </summary>
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Añade una entidad a la unidad de trajajo
        /// </summary>
        /// <param name="item">Entidad a añadir</param>
        /// <returns>Retorna una referencia a la entidad ya añadida</returns>
        TClassiffier Add<TClassiffier>(TClassiffier item) where TClassiffier : BaseNotMappedModel, IAggregateRoot;

        /// <summary>
        /// elimina una entidad a la unidad de trajajo
        /// </summary>
        /// <param name="item">Entidad a añadir</param>
        /// <returns>Retorna una referencia a la entidad ya añadida</returns>
        void Delete<TClassiffier>(TClassiffier item) where TClassiffier : BaseNotMappedModel, IAggregateRoot;

        /// <summary>
        /// Busca un clasificador basado en el ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TClassiffier> FindByIdAsync<TClassiffier>(int id) where TClassiffier : BaseNotMappedModel, IAggregateRoot;

        /// <summary>
        /// Busca un clasificador con el mismo nombre que el parámetro dado
        /// </summary>
        /// <param name="description">Nombre del clasificador a buscar</param>
        /// <returns></returns>
        IEnumerable<IBaseClassifier> FindByName<TClassiffier>(string description) where TClassiffier : BaseNotMappedModel, IAggregateRoot, IBaseClassifier;

        /// <summary>
        /// Actualiza una entidad a la unidad de trajajo
        /// </summary>
        /// <param name="item">Entidad a añadir</param>
        /// <returns>Retorna una referencia a la entidad ya añadida</returns>
        TClassiffier Update<TClassiffier>(TClassiffier item) where TClassiffier : BaseNotMappedModel, IAggregateRoot;
    }
}