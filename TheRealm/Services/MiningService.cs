using TheRealm.Middlewares;

namespace TheRealm.Services
{
    public class MiningService
    {
        private readonly IRedisService _redisService;
        private Random _random;
        private int _tools;

        private const string GoldKey = "gold";
        private const string IronKey = "iron";
        private const string CoalKey = "coal";
        private const string ServiceKey = "mining";

        public MiningService(IRedisService redisService)
        {
            _redisService = redisService;
            _random = new Random();
            _tools = Convert.ToInt32(_redisService.GetFromDatabase(ServiceKey).Result);
        }

        public Dictionary<string, int> GetCoal() 
        {
            var coalProduced = GenerateCargoValue();
            var avilableTools = _tools - coalProduced;
            if (avilableTools > 0) { 

                _redisService.SaveToDatabase(ServiceKey, (avilableTools).ToString());
                _redisService.SaveToDatabase(GoldKey,coalProduced.ToString());
            }

            return new Dictionary<string, int> { { CoalKey, coalProduced } };
        }

        public Dictionary<string, int> GetIron() 
        {
            var ironProduced = GenerateCargoValue();
            var avilableTools = _tools - ironProduced;
            if (avilableTools > 0)
            {
                _redisService.SaveToDatabase(ServiceKey, (avilableTools).ToString());
                _redisService.SaveToDatabase(IronKey, ironProduced.ToString());

            }
            return new Dictionary<string, int> { { IronKey, ironProduced } };
        }

        public Dictionary<string, int> GetGold() 
        {
            var goldProduced = GenerateCargoValue();
            var avilableTools = _tools - goldProduced;
            if (avilableTools > 0)
            {
                _redisService.SaveToDatabase(ServiceKey, (avilableTools).ToString());
                _redisService.SaveToDatabase(GoldKey, goldProduced.ToString());
            }
            return new Dictionary<string, int> { { GoldKey, goldProduced } };
        }

        public string SendTools(int value) => "Received";
        private int GenerateCargoValue() => _random.Next(0, 10);
    }
}
