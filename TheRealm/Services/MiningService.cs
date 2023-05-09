using TheRealm.Middlewares;
using TheRealm.Utils;

namespace TheRealm.Services
{
    public class MiningService : IMiningService
    {
        private readonly IRedisService _redisService;
        private ProductionUtils _productionUtils;
        private int _tools;

        private const string GoldKey = "gold";
        private const string IronKey = "iron";
        private const string CoalKey = "coal";
        private const string ServiceKey = "mining";

        public MiningService(IRedisService redisService)
        {
            _redisService = redisService;
            _productionUtils = new ProductionUtils();
            _tools = Convert.ToInt32(_redisService.GetFromDatabase(ServiceKey).Result);
        }

        public Dictionary<string, int> GetCoal()
        {
            var coal = _productionUtils.ProduceResource(CoalKey, ServiceKey, _tools, _redisService);

            return new Dictionary<string, int> { { CoalKey, coal } };
        }

        public Dictionary<string, int> GetIron()
        {
            var iron = _productionUtils.ProduceResource(IronKey, ServiceKey, _tools, _redisService);
            
            return new Dictionary<string, int> { { IronKey, iron } };
        }

        public Dictionary<string, int> GetGold()
        {
            var gold = _productionUtils.ProduceResource(GoldKey, ServiceKey, _tools, _redisService);
            
            return new Dictionary<string, int> { { GoldKey, gold } };
        }

        public string SendTools(int value) => "Received";
    
    }
}
