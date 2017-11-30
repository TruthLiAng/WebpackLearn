using System;
using System.Collections.Generic;
using System.Text;
using Webpack.Domain.IRepositories;
using Webpack.Domain.Models;

namespace Webpack.Domain.Services
{
    public sealed class TaskServer : ITaskServer
    {
        private readonly ITaskRepository _taskRepository;

        public TaskServer(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void CreateUser()
        {
            var user = new Task();
            _taskRepository.Create(user);
        }

        public int BatchUpdateBirthDay()
        {
            return _taskRepository.BatchUpdateUserName();
        }
    }
}
