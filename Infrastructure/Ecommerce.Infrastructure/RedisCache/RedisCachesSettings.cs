using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.RedisCache
{
    public class RedisCachesSettings
    {
        public string ConnectionString { get; set; }
        public string InstanceName { get; set; }
    }
}
