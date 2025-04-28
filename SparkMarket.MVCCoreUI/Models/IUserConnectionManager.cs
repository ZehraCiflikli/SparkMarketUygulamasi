namespace SparkMarket.MVCCoreUI.Models
{
    public interface IUserConnectionManager
    {
        void AddConnection(string userId, string connectionId);
        void RemoveConnection(string connectionId);
        List<string> GetConnectionId(string userId);

    }
}
