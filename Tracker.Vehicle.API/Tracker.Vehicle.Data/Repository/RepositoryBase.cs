using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Tracker.Vehicle.Data.Repository
{
    /// <summary>
    /// The abstract base class for the repository base.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        /// <summary>
        /// The DB context object of mongo DB .
        /// </summary>
        private readonly IMongoDatabase database;

        /// <summary>
        /// Repository base constructor
        /// </summary>
        /// <param name="repositoryContext"></param>
        public RepositoryBase(IConfiguration configuration)
        {
            var conStr = configuration.GetSection("ConnectionString:TrackerDB").Value;
            var client = new MongoClient(conStr);
            database = client.GetDatabase("TrackerDB");
        }


        /// <summary>
        /// Create an async task for inserting the given object entity to the data source.
        /// </summary>
        /// <param name="entity">The entity object.</param>
        /// <returns>The inserted object of the entity.</returns>
        public async Task Create(T entity)
        {
            await database.GetCollection<T>(entity.GetType().Name).InsertOneAsync(entity);
        }

        /// <summary>
        ///  Fetches and returns the list of given entity based on the condition.
        /// </summary>
        /// <param name="expression">The condition</param>
        /// <param name="collectionName">name of collection</param>
        /// <returns></returns>
        public async Task<IList<T>> FindByCondition(Expression<Func<T, bool>> expression, string collectionName)
        {
            var result= await this.database.GetCollection<T>(collectionName).FindAsync(expression);
            return await result.ToListAsync();
        }
    }
}
