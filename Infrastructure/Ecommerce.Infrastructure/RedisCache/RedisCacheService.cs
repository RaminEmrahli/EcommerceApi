using Ecommerce.Application.Interfaces.RedisCache;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.RedisCache
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IDatabase database;
        private readonly ConnectionMultiplexer redisConnection;
        private readonly RedisCachesSettings settings;
        public RedisCacheService(IOptions<RedisCachesSettings> options)
        {
            settings = options.Value;
            ConfigurationOptions opt = ConfigurationOptions.Parse(settings.ConnectionString);
            redisConnection = ConnectionMultiplexer.Connect(opt);
            database = redisConnection.GetDatabase();
        }
        public async Task<T> GetAsync<T>(string key)
        {
            var value= await database.StringGetAsync(key);
            if (value.HasValue)
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            return default;
        }

        public async Task SetAsync<T>(string key, T value, DateTime? expirationTime = null)
        {
            TimeSpan timeUntilExpiration = expirationTime.Value - DateTime.Now;
            await database.StringSetAsync(key, JsonConvert.SerializeObject(value), timeUntilExpiration);

        }
    }
}
