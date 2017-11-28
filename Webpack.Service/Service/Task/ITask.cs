using System;
using System.Collections.Generic;
using System.Text;
using Webpack.EntityFramework.Models;

namespace Webpack.Services.Service.Task
{
    public interface ITask
    {
        List<Webpack.EntityFramework.Models.Task> get();
    }
}
