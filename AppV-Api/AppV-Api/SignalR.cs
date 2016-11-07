using System;
using System.Net;
using Microsoft.AspNet.SignalR.Client;

namespace AppV_Api
{
    public class SignalR
    {
        async public void Start()
        {
            var hubConnection = new HubConnection("http://localhost:3979/");
            //hubConnection.TraceLevel = TraceLevels.All;
            //hubConnection.TraceWriter = Console.Out;
            IHubProxy hubProxy = hubConnection.CreateHubProxy("SignalRHub");
            hubProxy.On<string, string>("Send", (name, message) =>
            {
                Console.WriteLine("Incoming data: {0} {1}", name, message);
            });
            ServicePointManager.DefaultConnectionLimit = 10;
            await hubConnection.Start();
        }
    }
}