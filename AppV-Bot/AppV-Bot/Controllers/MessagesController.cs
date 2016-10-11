using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AppV_Bot.Facades.Luis;
using AppV_Bot.Facades.Packages;
using AppV_Bot.Models;
using AppV_Bot.Models.Luis;
using Microsoft.Bot.Connector;

namespace AppV_Bot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        private readonly PackagesFacade _packagesFacade;
        private readonly LuisFacade _luisFacade;

        public MessagesController()
        {
            _luisFacade = new LuisFacade();
            _packagesFacade = new PackagesFacade();
        }

        public async Task<List<PackageModel>> GetPackages(string packageName)
        {
            return await _packagesFacade.GetPackages(packageName);
        }

        public async Task<LuisModel> GetEntity(string query)
        {
            return await _luisFacade.GetEntity(query);
        } 

        //<summary>
        //POST: api/Messages
        //Receive a message from a user and reply to it
        //</summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {

            //                var packageList = await GetPackages();

            ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
            if (activity.Type == ActivityTypes.Message)
            {
                string returnMessage;
                var entity = await GetEntity(activity.Text);
                if (entity.intents.Count() > 0)
                {
                    switch (entity.intents[0].intent)
                    {
                        case "Package":
                            var packageList = await GetPackages(entity.entities[0].entity);
                            if (packageList.Count == 0)
                            {
                                returnMessage = $"Cannot find any packages with the name {entity.entities[0].entity}";
                            }
                            else
                            {
                                returnMessage = $"Package {packageList[0].Name} had id {packageList[0].PackageId}";
                            }
                            
                            break;
                        default:
                            returnMessage = "Sorry, I am not getting you...";
                            break;
                    }
                }
                else
                {
                    returnMessage = "Sorry, I am not getting you...";
                }

                Activity reply = activity.CreateReply(returnMessage);
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