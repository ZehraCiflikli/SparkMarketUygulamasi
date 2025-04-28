using Microsoft.AspNetCore.SignalR;

namespace SparkMarket.SignalR.Models
{
    public class MarketHub:Hub
    {
        // SignalR Server Tarafı Burasıdır. Talepler bu classa gelir. Bu classtan da client a gider.


        // Kullanıcı ID'lerini ve ConnectionId'lerini saklamak için bir dictionary
        private static Dictionary<string, string> _userConnections = new Dictionary<string, string>();

        // Kullanıcı bağlandığında çağrılacak metot
        public async Task RegisterUser(string userId)
        {
            // Kullanıcının eski bağlantısını temizle (eğer varsa)
            if (_userConnections.ContainsValue(Context.ConnectionId))
            {
                var oldKey = _userConnections.FirstOrDefault(x => x.Value == Context.ConnectionId).Key;
                _userConnections.Remove(oldKey);
            }

            // Yeni bağlantıyı kaydet
            _userConnections[userId] = Context.ConnectionId;
        }
        public async Task SendMessage(string user, string message)
        {
            // Veritabanına kaydet
            await Clients.All.SendAsync("ReceiveMessage", user, message);

            // Her veritabanındaki kullanıcı için, connection id değerini saklamam gerekir. (connecyion id hub classına bağlanan tüm clientlar için üretilen bir değer)  


         //   await Clients.Client(connectionId).SendAsync("ReceiveMessage", message);


        }

    }
}
