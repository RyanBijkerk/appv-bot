using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AppV_Bot.Facades;
using AppV_Bot.Models;
using Microsoft.Bot.Connector;

namespace AppV_Bot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        private readonly PackagesFacade _packagesFacade;

        public MessagesController()
        {
            _packagesFacade = new PackagesFacade();
        }

        public async Task<List<PackageModel>> GetPackages()
        {
            return await _packagesFacade.GetPackages();
        }


        //<summary>
        //POST: api/Messages
        //Receive a message from a user and reply to it
        //</summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
            if (activity.Type == ActivityTypes.Message)
            {
                var packageList = await GetPackages();
                var packageStr = "Oeps, something went wrong here!";

                if (packageList.Count == 0)
                {
                    packageStr = "I could not find any packages";
                }
                else
                {
                    packageStr = ($"I found {packageList.Count} package on the machine!");
                }
                
                // return our reply to the user
                Activity reply = activity.CreateReply(packageStr);
                await connector.Conversations.ReplyToActivityAsync(reply);
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}