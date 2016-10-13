using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AppV_Bot.Facades.Messages;
using Microsoft.Bot.Connector;

namespace AppV_Bot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        private readonly MessagesFacade _messagesFacade;

        public MessagesController()
        {
            _messagesFacade = new MessagesFacade();
        }

        public async Task<string> ResolveMessage(Activity activity)
        {
            return await _messagesFacade.ResolveMessage(activity);
        }

        //<summary>
        //POST: api/Messages
        //Receive a message from a user and reply to it
        //</summary>
        [Route("api/messages")]
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            var connector = new ConnectorClient(new Uri(activity.ServiceUrl));
            var returnMessage = await ResolveMessage(activity);
            var reply = activity.CreateReply(returnMessage);
            await connector.Conversations.ReplyToActivityAsync(reply);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}