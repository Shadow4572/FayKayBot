using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FayKayBot.Modules
{
    public class UserInfo : ModuleBase<SocketCommandContext>
    {
        [Command("userinfo")]
        public async Task UserInfoAsync([Remainder] string name)
        {
            try
            {
                var u = Context.Guild.Users;

                foreach (var v in u)
                {
                    if (v.Username == name || v.Nickname == name)
                    {
                        string username = v.ToString();
                        string nickname = v.Nickname;
                        string userIcon = v.GetAvatarUrl();
                        string userId = v.Id.ToString();
                        var userJoined = v.JoinedAt.Value.LocalDateTime;
                        var accountCreated = v.CreatedAt.LocalDateTime;
                        var accountAge = DateTime.Now.Subtract(accountCreated).Days;
                        string voiceChannel;
                        string game;
                        Color userColor = v.Roles.Last().Color;
                        string userStatus = v.Status.ToString();
                        var userRoles = v.Roles;
                        string userRolesString = "";
                        int userRolesCount = v.Roles.Count;

                        if (nickname == null)
                        {
                            nickname = v.Username;
                        }

                        if (v.VoiceChannel == null)
                        {
                            voiceChannel = "None";
                        }
                        else
                        {
                            voiceChannel = v.VoiceChannel.Name;
                        }

                        if (v.Game == null)
                        {
                            game = "None";
                        }
                        else
                        {
                            game = v.Game.ToString();
                        }

                        foreach (var r in userRoles)
                        {
                            if (r.Name == userRoles.Last().ToString())
                            {
                                userRolesString = userRolesString + r.Name;
                            }
                            else
                            {
                                userRolesString = userRolesString + r.Name + ", ";
                            }
                        }

                        EmbedBuilder builder = new EmbedBuilder();

                        builder.WithAuthor($"User info for {username}", userIcon)
                            .WithDescription($":white_small_square: **User ID:** {userId}\n:white_small_square: **Nickname:** {nickname}\n:white_small_square: **Join Date:** {userJoined}\n:white_small_square: **Account Created:** {accountCreated}\n:white_small_square: **Account Age:** {accountAge} days\n:white_small_square: **Voice Channel:** {voiceChannel}\n:white_small_square: **Playing:** {game}\n:white_small_square: **Colour:** {userColor.ToString().ToUpper()}\n:white_small_square: **User Status:** {userStatus}")
                            .WithThumbnailUrl(userIcon)
                            .WithColor(userColor)
                            .AddInlineField($"Roles ({userRolesCount})", $"{userRolesString}");

                        await ReplyAsync("", false, builder.Build());
                        return;
                    }
                }
                await ReplyAsync("No user with this name found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
