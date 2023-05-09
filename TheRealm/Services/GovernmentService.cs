namespace TheRealm.Services
{
    public class GovernmentService
    {
        private readonly IRedisService _redisService;
        public Dictionary<string,int> resourcesDict;
        private string GoldKey = "gold";
        private string IronKey = "iron";
        private string CoalKey = "coal";
        private string WoodKey = "wood";

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
