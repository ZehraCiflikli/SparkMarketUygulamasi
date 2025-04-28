using Microsoft.AspNetCore.SignalR;

namespace SparkMarket.MVCCoreUI.Models
{
    public class RaporHub : Hub
    {


        private readonly IUserConnectionManager _userConnectionManager;

        public RaporHub(IUserConnectionManager userConnectionManager)
        {
            _userConnectionManager = userConnectionManager;
        }

        // Kullanıcı ID'lerini ve ConnectionId'lerini saklamak için bir dictionary
        private static Dictionary<string, string> _userConnections = new Dictionary<string, string>();

        // Kullanıcı bağlandığında çağrılacak metot
        public async Task RegisterUser(string userId)
        {

            _userConnectionManager.AddConnection(userId,Context.ConnectionId);
        }

        public async Task SendMessageToUser(string targetUserId, string message)
        {
            if (_userConnections.TryGetValue(targetUserId, out string connectionId))
            {

                // Ben şu connection ID li arkadaşın connection on CompletedFile functionını çalıştır

                await Clients.Client(connectionId).SendAsync("CompletedFile", message);
            }
        }

        // Kullanıcı bağlantısı kesildiğinde kolleksiyondan çıkars
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var userId = _userConnections.FirstOrDefault(x => x.Value == Context.ConnectionId).Key;
            if (userId != null)
            {
                _userConnections.Remove(userId);
            }

            await base.OnDisconnectedAsync(exception);
        }
    }


}

