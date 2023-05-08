namespace TheRealm.Services
{
    public class MiningService
    {
        private readonly IRedisService _redisService;

        public MiningService(IRedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task GetCoal() {}

        public async Task GetIron() { }

        public async Task GetGold() { }

        public string SendTools(int value) => "Received";
    }
}
