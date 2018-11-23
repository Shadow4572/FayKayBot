using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FayKayBot.Modules
{
    public class ChannelInfo : ModuleBase<SocketCommandContext>
    {
        [Command("channelinfo")]
        public async Task ChannelInfoAsync([Remainder]string name)
        {
            var channels = Context.Guild.Channels;

            foreach (var ch in channels)
            {
                if (name == ch.Name)
                {
                    #region Variables
                    string channelId = ch.Id.ToString();
                    int channelPos = ch.Position;
                    string channelType = ch.GetType().Name;
                    int channelPerms = ch.PermissionOverwrites.Count;

                    if (channelType == "SocketTextChannel")
                    {
                        channelType = "Text Channel";
                        var channelMention = ch;
                        //string channelTopic =
                    }
                    else if (channelType == "SocketVoiceChannel")
                    {
                        channelType = "Voice Channel";
                    }

                    await ReplyAsync(channelType);
                    #endregion
                }
            }

            //EmbedBuilder builder = new EmbedBuilder();

            //builder.WithTitle("pong!")
            //    .WithDescription($":heartbeat: {Context.Client.Latency} ms")
            //    .WithColor(Color.Red);

            //await ReplyAsync("", false, builder.Build());
        }
    }
}
