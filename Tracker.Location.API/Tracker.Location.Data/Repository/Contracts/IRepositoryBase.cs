using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Tracker.Location.Data.Repository
{
    /// <summary>
    /// Repository base intreace with CRUD.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryBase<T>
    {
        /// <summary>
        /// Create an async task for inserting the given object entity to the data source..
        /// </summary>
        /// <param name="entity">The entity object.</param>
        /// <returns>The inserted object of the entity.</returns>
        Task Create(T entity);
    }
}
