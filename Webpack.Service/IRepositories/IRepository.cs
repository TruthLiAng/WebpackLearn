using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Webpack.Domain.IEntities;

namespace Webpack.Domain.IRepositories
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        /// <summary>
        /// 根据条件表达式获取集合
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<T>> FindByAsync(Expression<Func<T, bool>> predicate);

        IQueryable<T> FindQueryableByAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 根据对象全局唯一标识检索对象
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Task<T> RetrieveAsync(Guid ID);

        /// <summary>
        /// 根据条件表达式检索对象
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<T> RetrieveAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetAllAsync();

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();

        /// <summary>
        /// 根据条件表示分页获取数据集合
        /// </summary>
        /// <param name="predicate">断言表达式</param>
        /// <param name="sortPredicate">排序断言</param>
        /// <param name="sortOrder">排序方式</param>
        /// <param name="skip">跳过序列中指定数量的元素，然后返回剩余的元素</param>
        /// <param name="take">从序列的开头返回指定数量的连续元素</param>
        /// <returns>item1：数据集合；item2：数据总数</returns>
        Task<Tuple<List<T>, int>> GetAllAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, dynamic>> sortPredicate, SortOrder sortOrder, int skip, int take);

        Task<bool> Create(T model);

        Task<bool> Delete(T model);
    }
}
