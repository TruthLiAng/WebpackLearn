using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Webpack.Domain.IEntities;
using Webpack.Domain.IRepositories;

namespace Webpack.Infrastructure.Repositories
{
    public class RepositoryImpl<T> : IRepository<T> where T : class, IEntity, new()
    {
        protected readonly DbContext Context;

        protected RepositoryImpl(IContextHelper contextHelper)
        {
            Context = contextHelper.DbContext;
        }

        public virtual async Task<List<T>> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().Where(predicate).ToListAsync();
        }

        public virtual IQueryable<T> FindQueryableByAsync(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public List<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public virtual async Task<Tuple<List<T>, int>> GetAllAsync(Expression<Func<T, bool>> predicate,
            Expression<Func<T, dynamic>> sortPredicate, SortOrder sortOrder, int skip, int take)
        {
            var result = Context.Set<T>().Where(predicate);
            var total = result.Count();
            switch (sortOrder)
            {

                case SortOrder.Ascending:
                    var resultAscPaged = await
                        Context.Set<T>().Where(predicate).OrderBy(sortPredicate).Skip(skip).Take(take).ToListAsync();
                    return new Tuple<List<T>, int>(resultAscPaged, total);


                case SortOrder.Descending:
                    var resultDescPaged = await
                        Context.Set<T>().Where(predicate)
                            .OrderByDescending(sortPredicate)
                            .Skip(skip)
                            .Take(take).ToListAsync();
                    return new Tuple<List<T>, int>(resultDescPaged, total);
            }
            throw new InvalidOperationException("基于分页功能的查询必须指定排序字段和排序顺序。");
        }

        public virtual async Task<T> RetrieveAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<T> RetrieveAsync(Guid id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public virtual async Task<bool> Create(T model)
        {
            Context.Set<T>().Add(model);
            return await Context.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> Delete(T model)
        {
            Context.Set<T>().Remove(model);
            return await Context.SaveChangesAsync() > 0;
        }
    }
}
