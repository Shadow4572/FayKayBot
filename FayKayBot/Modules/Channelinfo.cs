using Discord;
using Discord.Commands;
using Discord.WebSocket;
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
                    string channelMention = "";
                    string channelTopic = "";
                    int channelBitRate = 0;
                    int channelConectedUsers = 0;
                    var channelCreated = ch.CreatedAt.LocalDateTime;
                    EmbedBuilder builder = new EmbedBuilder();
                    #endregion

                    #region Initializing variables
                    if (channelType == "SocketTextChannel")
                    {
                        channelType = "Text Channel";
                        channelMention = ch.Guild.GetTextChannel(ch.Id).Mention;
                        channelTopic = ch.Guild.GetTextChannel(ch.Id).Topic;
                    }
                    else if (channelType == "SocketVoiceChannel")
                    {
                        channelType = "Voice Channel";
                        channelBitRate = ch.Guild.GetVoiceChannel(ch.Id).Bitrate;
                        channelConectedUsers = ch.Guild.GetVoiceChannel(ch.Id).Users.Count;
                    }
                    #endregion

                    if (channelType == "Text Channel")
                    {
                        builder.WithTitle(channelName)
                            .AddInlineField("ID", channelId)
                            .AddInlineField("Position", channelPos)
                            .AddInlineField("Channel Type", channelType)
                            .AddInlineField("Mention", channelMention)
                            .AddInlineField("Permission Overwrites", channelPerms)
                            .AddField("Topic", channelTopic)
                            .WithFooter($"Creation date: {channelCreated}")
                            .WithColor(Color.Red);

                        await ReplyAsync("", false, builder.Build());
                        return;
                    }
                    else if (channelType == "Voice Channel")
                    {
                        builder.WithTitle(channelName)
                            .AddInlineField("ID", channelId)
                            .AddInlineField("Position", channelPos)
                            .AddInlineField("Channel Type", channelType)
                            .AddInlineField("Voice Bitrate", channelBitRate)
                            .AddInlineField("Connected Users", channelConectedUsers)
                            .AddInlineField("Permission Overwrites", channelPerms)
                            .WithFooter($"Creation date: {channelCreated}")
                            .WithColor(Color.Red);

                        await ReplyAsync("", false, builder.Build());
                        return;
                    }
                }
            }
            await ReplyAsync("No channel with this name found.");
        }
    }
}
