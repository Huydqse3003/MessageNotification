

namespace Application.SignalRHub
{
    public static class ConnectedUsers
    {
        private static readonly Dictionary<string, HashSet<string>> _connections = new();

        public static void AddUser(string userId, string connectionId)
        {
            lock (_connections)
            {
                if (!_connections.ContainsKey(userId))
                {
                    _connections[userId] = new HashSet<string>();
                }
                _connections[userId].Add(connectionId);
            }
        }

        public static void RemoveUser(string userId, string connectionId)
        {
            lock (_connections)
            {
                if (!_connections.ContainsKey(userId)) return;

                _connections[userId].Remove(connectionId);

                if (_connections[userId].Count == 0)
                {
                    _connections.Remove(userId);
                }
            }
        }
    }
}
