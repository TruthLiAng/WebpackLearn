using Microsoft.EntityFrameworkCore;
using Webpack.EntityFramework.EntityFramework;

namespace Webpack.Infrastructure
{
    public class IContextHelper
    {
        private static IContextHelper _Instance = new IContextHelper();

        private IContextHelper()
        {
        }

        /// <summary>
        /// 实例
        /// </summary>
        public static IContextHelper Instance
        {
            get
            {
                _Instance.DbContext = new ApplicationDbContext();
                return _Instance;
            }
        }

        public DbContext DbContext { get; private set; }
    }
}