using System;
using System.Text;
using DSharpPlus;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using DSharpPlus.CommandsNext;
using my_first_discord_bot.Commands;

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
            var json = string.Empty;

            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync().ConfigureAwait(false);

            var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);

            // Configuration for the bot
            var discord = new DiscordClient(new DiscordConfiguration()
                {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                Intents = DiscordIntents.All,
                MinimumLogLevel = LogLevel.Debug,
                LogTimestampFormat = "MMM dd yyyy - hh:mm:ss tt"
            });

            // Set prefix for commands
            var commands = discord.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = new[] { "!" }
            });

            // Call FirstModule, which has commands in it
            commands.RegisterCommands<FirstModule>();


            // Test for bot functionality
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