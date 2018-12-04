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
                    SocketGuildChannel channelMention = null;
                    string channelTopic = "";
                    int channelBitRate;
                    int channelConectedUsers;
                    var channelCreated = ch.CreatedAt.LocalDateTime;
                    var channelAge = DateTime.Now.Subtract(channelCreated);
                    int channelYears = channelAge.Days / 365;
                    int channelMonths = (channelAge.Days - (channelYears * 365)) / 30;
                    int channelWeeks = (channelAge.Days - (channelYears * 365 + channelMonths * 30)) / 7;
                    int channelDays = channelAge.Days - (channelYears * 365 + channelMonths * 30 + channelWeeks * 7);
                    int channelHours = channelAge.Hours;

                    if (channelType == "SocketTextChannel")
                    {
                        channelType = "Text Channel";
                        channelMention = ch;
                        channelTopic = ch.Guild.GetTextChannel(ch.Id).Topic;
                    }
                    else if (channelType == "SocketVoiceChannel")
                    {
                        channelType = "Voice Channel";
                        channelBitRate = ch.Guild.GetVoiceChannel(ch.Id).Bitrate;
                        channelConectedUsers = ch.Guild.GetVoiceChannel(ch.Id).Users.Count;
                    }

                    EmbedBuilder builder = new EmbedBuilder();

                    if (channelType == "Text Channel")
                    {
                        builder.WithTitle(channelName)
                            .AddInlineField("ID", channelId)
                            .AddInlineField("Position", channelPos)
                            .AddInlineField("Channel Type", channelType)
                            .AddInlineField("Mention", channelMention)
                            .AddInlineField("Permission Overwrites", channelPerms)
                            .AddField("Topic", channelTopic)
                            .WithFooter($"Years: {channelYears}, Months: {channelMonths}, Weeks: {channelWeeks}, Days: {channelDays}, Hours: {channelHours}")
                            .WithColor(Color.Red); 
                    }

                    await ReplyAsync("", false, builder.Build());
                    #endregion
                }
            }
        }
    }
}
