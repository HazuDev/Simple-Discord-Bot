using Discord.WebSocket;
using Discord;
using System.Threading.Tasks;
using System;
using System.IO;
using Discord.Commands;

namespace Discord_Bot
{
    class Program
    {
        static void Main(String[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;

        public async Task MainAsync()
        {
            var config = new DiscordSocketConfig
            {
                GatewayIntents = GatewayIntents.Guilds | GatewayIntents.GuildMembers | GatewayIntents.GuildMessages | GatewayIntents.MessageContent
            };

            _client = new DiscordSocketClient(config);
            _client.Log += Log;

            string token = ""; //Your token here!

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            _client.MessageReceived += MessageReceived;
            await Task.Delay(-1);
        }

        private async Task MessageReceived(SocketMessage msg)
        {
            string[] PunchGifs = { "https://64.media.tumblr.com/87cf5f3000abbf2e9e16f43d578907d7/tumblr_mwdfarClop1qa94xto1_500.gif", "https://i.pinimg.com/originals/d3/2d/bf/d32dbfa92611d1d1cab229d8024c39a8.gif", "https://i.pinimg.com/originals/12/b7/88/12b78850ab3e23d65cae344924df2e09.gif", "https://giffiles.alphacoders.com/764/76498.gif", "https://i.pinimg.com/originals/bc/23/d6/bc23d6b33759d17244ebe3b4df2b2415.gif" };
            string[] PatGifs = { "https://media.tenor.com/ntls_fAWhZEAAAAC/sakuya-izayoi-sakuya.gif", "https://media.tenor.com/aQcDBR5RFn4AAAAC/touhou-pat.gif" };

            if(msg.Content.StartsWith("!punch "))
            {
                await BotCommands.ResponseGif(PunchGifs, msg, "has brutally beaten");
            } 
            else if(msg.Content.StartsWith("!pat "))
            {
                await BotCommands.ResponseGif(PatGifs, msg, "patted");
            }
            else if(msg.Content.StartsWith("!ban "))
            {
                await BotCommands.BanCommand(msg);
            }
            else if(msg.Content.StartsWith("!kick "))
            {
                await BotCommands.KickCommand(msg);
            }
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine("> " + msg.ToString());
            return Task.CompletedTask;
        }
    }
}
