using Microsoft.ApplicationInsights.AspNetCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ExadelBonusPlus.Services.Models;
using MongoDB.Driver;

namespace ExadelBonusPlus.DataAccess.Repositories
{
    /// <summary>
    /// Class Repository.
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    /// <seealso cref="System.IDisposable" />
    public class MongoDBRepository<T> : IRepositoryAsync<T>
        where T : Entity
    {
        /// <summary>
        /// The context
        /// </summary>
        protected readonly IMongoDatabase Context;

        /// <summary>
        /// The db set
        /// </summary>
        protected readonly DbSet<T> DbSet;
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public MongoDBRepository(IMongoDatabase context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        /// <summary>
        /// add model to repository
        /// </summary>
        /// <param name="model">model user</param>
        /// <returns>db entry</returns>
        /// <exception cref="ArgumentNullException">if model = null</exception>
        public virtual async Task<T> AddAsync(T model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var result = DbSet.Add(model);
            await Context.SaveChangesAsync().ConfigureAwait(false);
            return result;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        ~MongoDBRepository()
        {
            Dispose(false);
        }


        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="flag"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool flag)
        {
            if (_disposed)
            {
                return;
            }

            Context.Dispose();
            _disposed = true;

            if (flag)
            {
                GC.SuppressFinalize(this);
            }
        }
    }
}
