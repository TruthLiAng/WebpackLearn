using System;
using System.Collections.Generic;
using System.Text;
using Webpack.Domain.IEntities;

namespace Webpack.Domain.Models
{
    public class Task : IEntity
    {
        public int Id { set; get; }
        public string name { set; get; }

        public string type { set; get; }
    }
}
