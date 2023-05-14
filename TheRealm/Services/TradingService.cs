namespace TheRealm.Services
{
    public class TradingService
    {
        private readonly IRedisService _redisService;
        private readonly GovernmentService _governmentService;
        private string GoldKey = "gold";
        private string IronKey = "iron";
        private string CoalKey = "coal";
        private string WoodKey = "wood";

        public TradingService(IRedisService redisService, GovernmentService governmentService)
        {
            _redisService = redisService;
            _governmentService = governmentService;
        }

        private void Sell(string resourceKey, int amount) 
        { 
            switch (resourceKey)
            {
                case "gold":
                    bool hasGold = _governmentService.resourcesDict.TryGetValue(GoldKey, out int GoldValue);
                    if (hasGold)
                    {
                        if(GoldValue > amount)
                        {
                            _redisService.SaveToDatabase(GoldKey, (GoldValue - amount).ToString());
                        }
                    }
                    break;
                case "iron":
                    bool hasIron = _governmentService.resourcesDict.TryGetValue(IronKey, out int IronValue);
                    if (hasIron)
                    {
                        if (IronValue > amount)
                        {
                            _redisService.SaveToDatabase(GoldKey, (IronValue - amount).ToString());
                        }
                    }
                    break;
                case "coal":
                    bool hasCoal = _governmentService.resourcesDict.TryGetValue(GoldKey, out int CoalValue);
                    if (hasCoal)
                    {
                        if (CoalValue > amount)
                        {
                            _redisService.SaveToDatabase(GoldKey, (CoalValue - amount).ToString());
                        }
                    }
                    break;
                case "wood":
                    bool hasWood = _governmentService.resourcesDict.TryGetValue(GoldKey, out int WoodValue);
                    if (hasWood)
                    {
                        if (WoodValue > amount)
                        {
                            _redisService.SaveToDatabase(GoldKey, (WoodValue - amount).ToString());
                        }
                    }
                    break;
                default:
                    //Default Implementation
                    break;

            }
        }
        private void Buy(string resourceKey, int amount)
        {
            switch (resourceKey)
            {
                case "gold":
                    int amountOfGold = Convert.ToInt32(_redisService.GetFromDatabase(GoldKey));
                    _redisService.SaveToDatabase(GoldKey, (amountOfGold + amount).ToString());
                    break;
                case "iron":
                    int amountOfIron = Convert.ToInt32(_redisService.GetFromDatabase(IronKey));
                    _redisService.SaveToDatabase(GoldKey, (amountOfIron + amount).ToString());
                    break;
                case "coal":
                    int amountOfCoal = Convert.ToInt32(_redisService.GetFromDatabase(CoalKey));
                    _redisService.SaveToDatabase(GoldKey, (amountOfCoal + amount).ToString());
                    break;
                case "wood":
                    int amountOfWood = Convert.ToInt32(_redisService.GetFromDatabase(WoodKey));
                    _redisService.SaveToDatabase(GoldKey, (amountOfWood + amount).ToString());
                    break;
                default:
                    //Default Implementation
                    break;
            }
        }
    }
}
