using System;
using DSharpPlus;
using System.Threading.Tasks;

namespace my_first_discord_bot
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }
        static async Task MainAsync()
        {
            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = "MTA1MDMzMjk3ODI5MjcyMzc2Mw.GPpiKU.8qwG1DDnn229ll6MClQVdN0FkRzEl7JI163yOE",
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged
            });

            discord.MessageCreated += async (s, e) =>
            {
                string contentMessage = e.Message.Content.ToLower();
                if (contentMessage.StartsWith("ping"))
                    await e.Message.RespondAsync("pong!");
            };

            await discord.ConnectAsync();
            await Task.Delay(-1);

        }
    }
}