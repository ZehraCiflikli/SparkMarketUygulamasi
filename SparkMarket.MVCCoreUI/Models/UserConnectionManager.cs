namespace SparkMarket.MVCCoreUI.Models
{
    public class UserConnectionManager : IUserConnectionManager
    {
        private static readonly Dictionary<string, HashSet<string>> _userConnections = new();
        private static readonly object _lock = new();

        public void AddConnection(string userId, string connectionId)
        {
            lock (_lock)
            {
                if (!_userConnections.TryGetValue(userId, out var connections))
                {
                    connections = new HashSet<string>();
                    _userConnections[userId] = connections;
                }

                connections.Add(connectionId);
            }
        }

        public void RemoveConnection(string connectionId)
        {
            lock (_lock)
            {
                // Kullanıcıyı bul, bağlantıya sahip olanı buluyoruz
                var userEntry = _userConnections.FirstOrDefault(pair => pair.Value.Contains(connectionId));

                if (!string.IsNullOrEmpty(userEntry.Key))
                {
                    userEntry.Value.Remove(connectionId);

                    // Eğer kullanıcının başka bağlantısı kalmadıysa, kullanıcıyı da sil
                    if (userEntry.Value.Count == 0)
                    {
                        _userConnections.Remove(userEntry.Key);
                    }
                }
            }
        }

        public List<string> GetConnectionId(string userId)
        {
            lock (_lock)
            {
                if (_userConnections.TryGetValue(userId, out var connections))
                {
                    return connections.ToList();
                }

                return new List<string>();
            }
        }


    }

}
