namespace TheRealm.Services
{
    public class LumberMillService
    {
        private readonly IRedisService _redisService;
        private Random _random;
        private int _tools;

        private const string CargoKey = "wood";
        private const string ServiceKey = "lumberMill";

        public LumberMillService(IRedisService redisService)
        {
            _redisService = redisService;
            _random = new Random();
            _tools = Convert.ToInt32(_redisService.GetFromDatabase(ServiceKey).Result);
        }

        public Dictionary<string, int> GetWood()
        {
            var woodProduced = GenerateCargoValue();
            _redisService.SaveToDatabase(ServiceKey, (_tools - woodProduced).ToString());
            return new Dictionary<string, int> { { CargoKey, woodProduced } };
        }

        public async Task<bool> SendTools(int value) => await _redisService.SaveToDatabase(ServiceKey, value.ToString());

        private int GenerateCargoValue() => _random.Next(0, 10);
    }
}
