using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webpack.Domain.IEntities;
using Webpack.Domain.UnitOfWork;

namespace Webpack.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext DbContext { get; set; }
        public UnitOfWork(IContextHelper contextHelp)
        {
            DbContext = contextHelp.DbContext;
        }

        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        public virtual async Task CommitAsync()
        {
            // Save changes with the default options
            try
            {
                await DbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
            }

        }

        /// <summary>
        /// Disposes the current object
        /// </summary>
        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (DbContext == null) return;

            DbContext.Dispose();
            DbContext = null;
        }

        public virtual void RegisterNew<TEntity>(TEntity obj) where TEntity : class, IEntity
        {
            DbContext.Set<TEntity>().Add(obj);
        }

        public virtual void RegisterModified<TEntity>(TEntity obj) where TEntity : class
        {
            DbContext.Entry(obj).State = EntityState.Modified;
        }

        public virtual void RegisterDeleted<TEntity>(TEntity obj) where TEntity : class
        {
            DbContext.Entry(obj).State = EntityState.Deleted;
        }

    }
}
