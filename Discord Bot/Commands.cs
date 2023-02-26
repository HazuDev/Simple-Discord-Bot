using Discord.WebSocket;
using Discord;
using System.Threading.Tasks;
using System;
using System.IO;
using Discord.Commands;

namespace Discord_Bot
{
    internal class BotCommands
    {
        public static async Task ResponseGif(string[] arr, SocketMessage msg, string text)
        {
            var mentions = msg.MentionedUsers;

            if (mentions.Any())
            {
                foreach (var user in mentions)
                {
                    Random rnd = new Random();

                    int i = rnd.Next(arr.Length);
                    string randomGif = arr[i];

                    EmbedBuilder embedBuilder = new EmbedBuilder
                    {
                        Title = $"{msg.Author.Username} {text} {user.Username}",
                        ImageUrl = randomGif,
                        Color = new Color(237, 70, 70)
                    };

                    await msg.Channel.SendMessageAsync(embed: embedBuilder.Build());
                }
            }
        }

        public static async Task BanCommand(SocketMessage msg)
        {
            var author = msg.Author as SocketGuildUser;

            if(author.GuildPermissions.Administrator)
            {
                var mentions = msg.MentionedUsers;

                if(mentions.Any())
                {
                    foreach(var user in mentions)
                    {
                        var guildUser = msg.Channel is SocketGuildChannel guildChannel ? guildChannel.Guild.GetUser(user.Id) : null;

                        if(guildUser != null)
                        {
                            try
                            {
                                await guildUser.Guild.AddBanAsync(guildUser, reason: $"{msg.Author.Username}");

                                EmbedBuilder embedBuilder = new EmbedBuilder
                                {
                                    Title = "The user has been banned",
                                    Color = new Color(6, 245, 129)
                                };

                                await msg.Channel.SendMessageAsync(embed: embedBuilder.Build());
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);

                                EmbedBuilder embedBuilder = new EmbedBuilder
                                {
                                    Title = "Error trying to ban this user!",
                                    Color = new Color(255, 72, 64)
                                };

                                await msg.Channel.SendMessageAsync(embed: embedBuilder.Build());
                            }
                        }
                    }
                }
            }
        }

        public static async Task KickCommand(SocketMessage msg)
        {
            var author = msg.Author as SocketGuildUser;

            if (author.GuildPermissions.Administrator)
            {
                var mentions = msg.MentionedUsers;

                if (mentions.Any())
                {
                    foreach (var user in mentions)
                    {
                        var guildUser = msg.Channel is SocketGuildChannel guildChannel ? guildChannel.Guild.GetUser(user.Id) : null;

                        if (guildUser != null)
                        {
                            try
                            {
                                await guildUser.Guild.AddBanAsync(guildUser, reason: $"{msg.Author.Username}");

                                EmbedBuilder embedBuilder = new EmbedBuilder
                                {
                                    Title = "The user has been kicked",
                                    Color = new Color(6, 245, 129)
                                };

                                await msg.Channel.SendMessageAsync(embed: embedBuilder.Build());
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);

                                EmbedBuilder embedBuilder = new EmbedBuilder
                                {
                                    Title = "Error trying to kick this user!",
                                    Color = new Color(255, 72, 64)
                                };

                                await msg.Channel.SendMessageAsync(embed: embedBuilder.Build());
                            }
                        }
                    }
                }
            }
        }
    }
}
