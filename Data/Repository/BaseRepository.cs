
using CoreCommand.Repository;
using CoreDomain.Domain;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Command.Repository
{
    public abstract class BaseRepository<TEntity> :
                         BaseRepository<TEntity, DataBaseContext>
                         where TEntity : BaseNotMappedModel, IAggregateRoot
    {
        protected BaseRepository(DataBaseContext context) : base(context) { }
    }
}
