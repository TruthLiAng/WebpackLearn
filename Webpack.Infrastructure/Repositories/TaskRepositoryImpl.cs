using Webpack.Domain.IRepositories;
using Webpack.Domain.Models;

namespace Webpack.Infrastructure.Repositories
{
    public sealed class TaskRepositoryImpl : RepositoryImpl<Task>, ITaskRepository
    {
        public TaskRepositoryImpl(IContextHelper contextHelper) : base(contextHelper)
        {

        }
        public int BatchUpdateUserName()
        {

            return 1;
        }
    }
}
