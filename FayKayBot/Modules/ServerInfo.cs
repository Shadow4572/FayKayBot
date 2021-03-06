﻿using Discord;
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
            #region Variables
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
            var serverRoles = Context.Guild.Roles;
            string serverRolesString = "";
            int serverRolesCount = Context.Guild.Roles.Count;
            ulong serverId = Context.Guild.Id;
            var emotes = Context.Guild.Emotes;
            string emotesString = "";
            int emotesCount = Context.Guild.Emotes.Count;
            #endregion

            #region Initializing variables
            foreach (var v in u)
            {
                if (v.Status.ToString() != "Offline")
                {
                    onlineUsers++;
                }
            }

            foreach (var r in serverRoles)
            {
                if (r.Name == serverRoles.Last().ToString())
                {
                    serverRolesString = serverRolesString + r.Name;
                }
                else
                {
                    serverRolesString = serverRolesString + r.Name + ", ";
                }
            }

            foreach (var e in emotes)
            {
                emotesString = emotesString + ":" + e.Name + ": ";
            }
            #endregion

            EmbedBuilder builder = new EmbedBuilder();

            builder.WithAuthor("Server Information", serverIcon)
                .WithDescription($"Server information for {serverName}")
                .WithThumbnailUrl(serverIcon)
                .WithColor(Color.Red)
                .AddInlineField("Users (Online/Total)", $"{onlineUsers}/{totalUsers}")
                .AddInlineField("Creation Date", $"{creationDate}")
                .AddInlineField("Voice/Text Channels", $"{voiceChannels}/{textChannels}")
                .AddInlineField("Server Owner", $"{serverOwner}")
                .AddField("Server Region", $"{serverRegion}")
                .AddField($"Server Roles ({serverRolesCount})", $"{serverRolesString}")
                .AddField($"Emotes ({emotesCount})", $"{emotesString}")
                .WithFooter($"Server ID: {serverId}");

            await ReplyAsync("", false, builder.Build());

        }
    }
}
