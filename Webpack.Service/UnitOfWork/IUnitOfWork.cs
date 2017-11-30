using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Webpack.Domain.IEntities;

namespace Webpack.Domain.UnitOfWork
{
    /// <summary>
    /// Unit Of Work Pattern
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        DbContext DbContext { get; set; }

        /// <summary>
        /// 提交所有更改
        /// </summary>
        Task CommitAsync();

        #region Methods
        /// <summary>
        /// 将指定的聚合根标注为“新建”状态。
        /// </summary>
        /// <typeparam name="T">需要标注状态的聚合根类型。</typeparam>
        /// <param name="obj">需要标注状态的聚合根。</param>
        void RegisterNew<T>(T obj)
            where T : class, IEntity;
        /// <summary>
        /// 将指定的聚合根标注为“更改”状态。
        /// </summary>
        /// <typeparam name="T">需要标注状态的聚合根类型。</typeparam>
        /// <param name="obj">需要标注状态的聚合根。</param>
        void RegisterModified<T>(T obj)
            where T : class;
        /// <summary>
        /// 将指定的聚合根标注为“删除”状态。
        /// </summary>
        /// <typeparam name="T">需要标注状态的聚合根类型。</typeparam>
        /// <param name="obj">需要标注状态的聚合根。</param>
        void RegisterDeleted<T>(T obj)
            where T : class;
        #endregion
    }
}
