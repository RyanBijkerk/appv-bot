using System.Linq;
using System.Threading.Tasks;
using AppV_Bot.Services.Luis;
using AppV_Bot.Services.Messages;
using AppV_Bot.Services.Packages;
using Microsoft.Bot.Connector;

namespace AppV_Bot.Facades.Messages
{
    public class MessagesFacade
    {
        private readonly MessagesService _messagesService;
        private readonly LuisService _luisService;
        private readonly PackagesService _packagesService;


        public MessagesFacade()
        {
            _messagesService = new MessagesService();
            _luisService = new LuisService();
            _packagesService = new PackagesService();
        }


        public async Task<string> ResolveMessage(Activity activity)
        {
            var messageString = "";
            if (activity.Type == ActivityTypes.Message)
            {
                messageString = "Sorry, I am not getting you...";

                var entity = await _luisService.GetEntity(activity.Text);
                if (entity.intents.Any())
                {
                    switch (entity.intents[0].intent)
                    {
                        case "Introduction":
                            messageString = await _messagesService.CreateIntroMessage();

                            break;

                        case "CountPackages":
                            var packageListCount = await _packagesService.GetPackages();
                            messageString = await _messagesService.CreateCountPackagesMessage(packageListCount);

                            break;

                        case "ListPackages":
                            var packageList = await _packagesService.GetPackages();
                            messageString = await _messagesService.CreateListPackagesMessage(packageList);

                            break;

                        case "SearchPackage":
                            if (!entity.entities.Any())
                            {
                                break;
                            }

                            var package = await _packagesService.GetPackage(entity.entities[0].entity);
                            messageString =  await _messagesService.CreatePackageMessage(package);

                            break;

                        default:
                            messageString = "Sorry, I am not getting you...";

                            break;
                    }
                }
            }
            else
            {
                await _messagesService.HandleSystemMessage(activity);
            }

            return messageString;
        }
    }
}
