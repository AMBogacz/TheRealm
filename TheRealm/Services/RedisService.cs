using StackExchange.Redis;

namespace TheRealm.Services
{
    public class RedisService : IRedisService
    {
        private readonly IConnectionMultiplexer _redis;
        private readonly IDatabase _database;

        public RedisService(IConnectionMultiplexer redis)
        {
            _redis = redis;
            _database = _redis.GetDatabase();
        }

        public string GetRedisStatus()
        {
            return _redis.GetStatus();
        }

        public async Task<bool> SaveToDatabase(string key, string value) => await _database.StringSetAsync(key, value);

        public async Task<string> GetFromDatabase(string key) => await _database.StringGetAsync(key);
    }
}
