using TheRealm.Entities;
namespace TheRealm.Services
{
    public class GovernmentService
    {
        private readonly IRedisService _redisService;
        public Dictionary<string,int> resourcesDict;
        private string GoldKey = Product.Gold.ToString();
        private string IronKey = Product.Iron.ToString();
        private string CoalKey = Product.Coal.ToString();
        private string WoodKey = Product.Wood.ToString();

        public GovernmentService(IRedisService redisService)
        {
            _redisService = redisService;
        }

        public Dictionary<string, int> CheckWarehouse() 
        {
            var amountOfGold = Convert.ToInt32(_redisService.GetFromDatabase(GoldKey));
            var amountOfCoal = Convert.ToInt32(_redisService.GetFromDatabase(CoalKey));
            var amountOfIron = Convert.ToInt32(_redisService.GetFromDatabase(IronKey));
            var amountOfWood = Convert.ToInt32(_redisService.GetFromDatabase(WoodKey));

            resourcesDict.Add(GoldKey, amountOfGold);
            resourcesDict.Add(IronKey, amountOfIron);
            resourcesDict.Add(CoalKey, amountOfCoal);
            resourcesDict.Add(WoodKey, amountOfWood);

            return resourcesDict;
        }
    }

}
