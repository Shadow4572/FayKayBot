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
                    string channelName = ch.Name;
                    string channelId = ch.Id.ToString();
                    int channelPos = ch.Position;
                    string channelType = ch.GetType().Name;
                    int channelPerms = ch.PermissionOverwrites.Count;

                    if (channelType == "SocketTextChannel")
                    {
                        channelType = "Text Channel";
                        var channelMention = ch;
                        string channelTopic = ch.Guild.GetTextChannel(ch.Id).Topic;
                    }
                    else if (channelType == "SocketVoiceChannel")
                    {
                        channelType = "Voice Channel";
                        int channelBitRate = ch.Guild.GetVoiceChannel(ch.Id).Bitrate;
                        int channelConectedUsers = ch.Guild.GetVoiceChannel(ch.Id).Users.Count;
                    }

                    EmbedBuilder builder = new EmbedBuilder();

                    if (channelType == "Text Channel")
                    {
                        builder.WithTitle(channelName)
                            .AddInlineField("ID", channelId)
                            .AddInlineField("position", channelPos)
                            .AddInlineField("Channel Type", channelType)
                            .WithColor(Color.Red); 
                    }

                    await ReplyAsync("", false, builder.Build());
                    #endregion
                }
            }
        }
    }
}
