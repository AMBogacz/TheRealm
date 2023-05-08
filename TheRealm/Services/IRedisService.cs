namespace TheRealm.Services
{
    public interface IRedisService
    {
        Task<string> GetFromDatabase(string key);
        string GetRedisStatus();
        Task<bool> SaveToDatabase(string key, string value);
    }
}