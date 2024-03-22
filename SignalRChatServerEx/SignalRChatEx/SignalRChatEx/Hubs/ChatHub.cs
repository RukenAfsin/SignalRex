using Microsoft.AspNetCore.SignalR;
using SignalRChatEx.Data;
using SignalRChatEx.Models;

namespace SignalRChatEx.Hubs
{
    public class ChatHub:Hub
    {

        public async Task GetNickName(string nickName)
        {
            Client client = new Client
            {
                ConnectionId=Context.ConnectionId,
                NickName = nickName
            };

            ClientSource.Clients.Add(client);
          await   Clients.Others.SendAsync("clientJoined", nickName);

            await Clients.All.SendAsync("clients",ClientSource.Clients);
        }

        public async Task SendMessageAsync(string message, string clientName )
        {
            clientName = clientName.Trim();
            Client senderClient =ClientSource.Clients.FirstOrDefault(c=>c.ConnectionId == Context.ConnectionId);
            if(clientName=="Tümü")
            {
                await Clients.Others.SendAsync("receiveMessage", message);
            }
            else
            {
                Client client = ClientSource.Clients.FirstOrDefault(c => c.NickName == clientName);
                await Clients.Client(client.ConnectionId).SendAsync("receiveMessage", message,senderClient.NickName);

            }
        }

    }
}
