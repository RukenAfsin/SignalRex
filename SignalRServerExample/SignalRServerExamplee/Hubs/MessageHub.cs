using Microsoft.AspNetCore.SignalR;

namespace SignalRServerExample.Hubs
{
    public class MessageHub:Hub
    {
        //public async Task SendMessageAsync(string message IEnumerable<string> connectionIds)
        //public async Task SendMessageAsync(string message,string groupName, IEnumerable<string> connectionIds)
        //public async Task SendMessageAsync(string message, string groupName)
         //public async Task SendMessageAsync(string message,IEnumerable<string> groups)
             public async Task SendMessageAsync(string message, string groupName)
        {
            //All: servera bağlı olan tüm clientlar ile iletişim kurar
            //await Clients.All.SendAsync("receiveMessage",message);


            //await Clients.Caller.SendAsync("receiveMessage", message);
            //Caller: sadece servera bildirim gönderen client ile iletişim kurar

            //await Clients.Others.SendAsync("receiveMessage", message);
            //Sadece servera bildirim gönderen client dısında bağlı olan tüm clientlara bildirim gönderir


            //AllEcept: velirtilen clientlar hariç servera bağlı olan tüm clientlara bildiride bulunur.
            //await Clients.AllExcept(connectionIds).SendAsync("receivedMessage", message);


            //servera bağlı clientlar arasında belirli olana mesaj gönderilir
            //await   Clients.Client(connectionIds.First()).SendAsync("receiveMessage",message);


            //await Clients.Clients(connectionIds).SendAsync("receiveMessage", message);

            //Group:belirtilen grupraki clientlara bildirim gider önce gruplar belirtilip subscribe olunmalı

            //await  Clients.Group(groupName).SendAsync("receiveMessage", message);


            //groupexcept:belirtilen gruptaki belirtilen clientlar dısındaki tüm clientlara mesaj iletmemizi sağlayan fonksiyondur
            //await Clients.GroupExcept(groupName,connectionIds).SendAsync("receiveMessage",message);

            //group:It is a functon that we can send notification different clients at the same time
            //await Clients.Groups(groups).SendAsync("receivedMessage", message);

            //otheringroup:biildiride bulunan client haricinde gruptaki tüm clientlara bildiride bulunan fonksiyondur
            await Clients.OthersInGroup(groupName).SendAsync("receiveMessage", message);

        }

        public  override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
        }

        public async Task addGroup(string connectionId,string groupName)
        {
           await  Groups.AddToGroupAsync(connectionId, groupName);
        }
   
    }
}
