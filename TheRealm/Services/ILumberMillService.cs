namespace TheRealm.Services
{
    public interface ILumberMillService
    {
        Dictionary<string, int> GetWood();
        Task<bool> SendTools(int value);
    }
}