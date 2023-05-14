using TheRealm.Entities;
using TheRealm.Utils;

namespace TheRealm.Services
{
    public class LumberMillService : ILumberMillService
    {
        private readonly IRedisService _redisService;
        private ProductionUtils _productionUtils;
        private int _tools;

        private string ProductKey = Product.Wood.ToString();
        private string ServiceKey = ServiceType.LumberMill.ToString();

        public LumberMillService(IRedisService redisService)
        {
            _redisService = redisService;
            _productionUtils = new ProductionUtils();
            _tools = Convert.ToInt32(_redisService.GetFromDatabase(ServiceKey).Result);
        }

        public Dictionary<string, int> GetWood()
        {
            var wood = _productionUtils.ProduceResource(ProductKey, ServiceKey, _tools, _redisService);
            Console.WriteLine(wood);
            return new Dictionary<string, int> { { ProductKey, wood } };
        }

        public async Task<bool> SendTools(int value) => await _redisService.SaveToDatabase(ServiceKey, value.ToString());

    }
}
