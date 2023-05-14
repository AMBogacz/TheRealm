using System;
using TheRealm.Services;

namespace TheRealm.Utils
{
    public class ProductionUtils
    {
        private Random _random;

        public ProductionUtils()
        {
            _random = new Random();
        }

        public int GenerateProductionValue() => _random.Next(1, 10);

        public bool ValidateProductionCost(int toolsAmount, int productionAmount) => toolsAmount > productionAmount;

        public int ProduceResource(string resourceKey, string serviceKey, int tools, IRedisService redisService)
        {
            var resourceProduced = GenerateProductionValue();
            var isEnoughTools = ValidateProductionCost(tools, resourceProduced);
            var toolsLeft = 0;

            if (isEnoughTools)
            {
                toolsLeft = tools - resourceProduced;
                redisService.SaveToDatabase(serviceKey, toolsLeft.ToString());
                redisService.SaveToDatabase(resourceKey, resourceProduced.ToString());
                return resourceProduced;
            }

            redisService.SaveToDatabase(serviceKey, toolsLeft.ToString());
            redisService.SaveToDatabase(resourceKey, tools.ToString());
            return tools;
        }
    }
}
