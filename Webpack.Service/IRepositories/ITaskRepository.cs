using System;
using System.Collections.Generic;
using System.Text;
using Webpack.Domain.IRepositories;
using Webpack.Domain.Models;

namespace Webpack.Domain.IRepositories
{
    public interface ITaskRepository : IRepository<Task>
    {
        /// <summary>
        /// 批量修改用户名
        /// </summary>
        int BatchUpdateUserName();
    }
}
