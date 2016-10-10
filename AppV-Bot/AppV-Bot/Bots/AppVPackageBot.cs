using System;
using Microsoft.Bot.Builder.FormFlow;

namespace AppV_Bot.Bots
{
    public class AppVPackageBot
    {
        public enum AppVCommands
        {
            ListPackages, ListServers 
        };


        [Serializable]
        public class AppVCommand
        {
            public AppVCommands? AppVCommands;

            public static IForm<AppVCommand> BuildForm()
            {
                return new FormBuilder<AppVCommand>()
                        .Message("Welcome to the App-V command bot!")
                        .Build();
            }
        };

    }
}