namespace TheRealm.Services
{
    public class GovernmentService
    {
        private readonly IRedisService _redisService;

        public GovernmentService(IRedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task CheckWarehouse() { }
    }
}
