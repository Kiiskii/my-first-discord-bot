using System;
using System.Text;
using DSharpPlus;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

            var discord = new DiscordClient(new DiscordConfiguration()
                {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
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