namespace TheRealm.Services
{
    public interface IMiningService
    {
        Dictionary<string, int> GetCoal();
        Dictionary<string, int> GetGold();
        Dictionary<string, int> GetIron();
        string SendTools(int value);
    }
}