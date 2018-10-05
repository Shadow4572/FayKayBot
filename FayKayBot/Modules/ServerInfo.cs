using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FayKayBot.Modules
{
    public class ServerInfo : ModuleBase<SocketCommandContext>
    {
        [Command("serverinfo")]
        public async Task ServerInfoAsync()
        {
            var u = Context.Guild.Users;
            string serverName = Context.Guild.Name;
            int onlineUsers = 0;
            int totalUsers = Context.Guild.Users.Count;
            var creationDate = Context.Guild.CreatedAt.LocalDateTime;
            string serverIcon = Context.Guild.IconUrl;
            int textChannels = Context.Guild.TextChannels.Count;
            int voiceChannels = Context.Guild.VoiceChannels.Count;
            string serverOwner = Context.Guild.Owner.ToString();
            string serverRegion = Context.Guild.VoiceRegionId;

            foreach (var v in u)
            {
                if (v.Status.ToString() != "Offline")
                {
                    onlineUsers++;
                }
            }

            EmbedBuilder builder = new EmbedBuilder();

            builder.WithTitle("Server Information")
                .WithDescription($"Server information for {serverName}")
                .WithThumbnailUrl(serverIcon)
                .WithColor(Color.Red)
                .AddInlineField("Users (Online/Total)", $"{onlineUsers}/{totalUsers}")
                .AddInlineField("Creation Date", $"{creationDate}")
                .AddInlineField("Voice/Text Channels", $"{voiceChannels}/{textChannels}")
                .AddInlineField("Server Owner", $"{serverOwner}")
                .AddField("Server Region", $"{serverRegion}");

            await ReplyAsync("", false, builder.Build());

        }
    }
}
