using Microsoft.AspNet.SignalR;

namespace AppV_Bot.SignalR
{
    public class SignalRHub : Hub
    {
        public void Send(string name, string message)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<SignalRHub>();
            context.Clients.All.addMessage(name, message);
        }
    }
}