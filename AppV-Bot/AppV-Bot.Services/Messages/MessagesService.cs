using System.Collections.Generic;
using System.Threading.Tasks;
using AppV_Bot.Models;
using Microsoft.Bot.Connector;

namespace AppV_Bot.Services.Messages
{
    public class MessagesService
    {
        public async Task<string> CreatePackageMessage(PackageModel package)
        {
            return await Task.Run(() =>
            {
                string messageString = null;
                if (package.Name != null)
                {
                    messageString = $"I have found a package with the name {package.Name} with the following details: \n\n";
                    messageString += $"PackageId: {package.PackageId} \n\n";
                    messageString += $"VersionId: {package.VersionId} \n\n";
                    messageString += $"Name: {package.Name} \n\n";
                    messageString += $"Version: {package.Version} \n\n";
                    messageString += $"Path: {package.Path} \n\n";
                    messageString += $"IsPublishedToUser: {package.IsPublishedToUser} \n\n";
                    messageString += $"UserPending: {package.UserPending} \n\n";
                    messageString += $"IsPublishedGlobally: {package.IsPublishedGlobally} \n\n";
                    messageString += $"GlobalPending: {package.GlobalPending} \n\n";
                    messageString += $"InUse: {package.InUse} \n\n";
                    messageString += $"InUseByCurrentUser: {package.InUseByCurrentUser} \n\n";
                    messageString += $"PackageSize: {package.PackageSize} \n\n";
                    messageString += $"PercentLoaded: {package.PercentLoaded} \n\n";
                    messageString += $"IsLoading: {package.IsLoading} \n\n";
                    messageString += $"HasAssetIntelligence: {package.HasAssetIntelligence} \n\n";
                }
                return messageString;
            });
        }

        public async Task<string> CreateCountPackagesMessage(List<PackageModel> packageList)
        {
            return await Task.Run(() => packageList.Count > 0 ? $"I have found {packageList.Count} number of packages" : $"I could not find any packages");
        }
        
        
        public async Task HandleSystemMessage(Activity message)
        {
            await Task.Run(() =>
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
            });
        }
    }
}
