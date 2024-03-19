using Microsoft.AspNetCore.SignalR;

namespace SignalRServerExample.Hubs
{
    public class MessageHub:Hub
    {
        public async Task SendMessageAsync(string message)
        {
            //All: servera bağlı olan tüm clientlar ile iletişim kurar
            //await Clients.All.SendAsync("receiveMessage",message);


            //await Clients.Caller.SendAsync("receiveMessage", message);
            //Caller: sadece servera bildirim gönderen client ile iletişim kurar

            await Clients.Others.SendAsync("receiveMessage", message);
            //Sadece servera bildirim gönderen client dısında bağlı olan tüm clientlara bildirim gönderir


        }

        public  override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
        }
    }
}
