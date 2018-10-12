using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FayKayBot.Modules
{
    public class RoleInfo : ModuleBase<SocketCommandContext>
    {
        [Command("roleinfo")]
        public async Task RoleInfoAsync([Remainder] string name)
        {
            try
            {
                var roles = Context.Guild.Roles;

                foreach (var r in roles)
                {
                    if (r.Name == name)
                    {
                        #region Variables
                        string serverIcon = Context.Guild.IconUrl;
                        string roleName = r.Name;
                        string roleId = r.Id.ToString();
                        var roleCreated = r.CreatedAt.LocalDateTime;
                        var roleAge = DateTime.Now.Subtract(roleCreated).Days;
                        Color roleColor = r.Color;
                        int memberNumber = r.Members.Count();
                        int rolePosition = r.Position;
                        bool roleManaged = r.IsManaged;
                        bool roleHoisted = r.IsHoisted;
                        bool roleMentionable = r.IsMentionable;
                        var rolePermissions = r.Permissions.ToList();
                        int rolePermissionsCount = 0;
                        string rolePermissionsString = "";
                        #endregion

                        #region Initializing variables
                        if (roleColor.ToString() == "#0")
                        {
                            roleColor = Color.LightGrey;
                        }

                        foreach (var rp in rolePermissions)
                        {
                            if (rp.ToString() == rolePermissions.Last().ToString())
                            {
                                rolePermissionsString = rolePermissionsString + rp.ToString();
                                rolePermissionsCount++;
                            }
                            else
                            {
                                rolePermissionsString = rolePermissionsString + rp.ToString() + ", ";
                                rolePermissionsCount++;
                            }
                        }
                        #endregion

                        EmbedBuilder builder = new EmbedBuilder();

                        builder.WithAuthor($"Role information for {roleName}", serverIcon)
                            .WithDescription($":white_small_square: **Role ID:** {roleId}\n:white_small_square: **Role Created:** {roleCreated}\n:white_small_square: **Role Age:** {roleAge}\n:white_small_square: **Role Colour:** {roleColor.ToString().ToUpper()}\n:white_small_square: **Number of members:** {memberNumber}\n:white_small_square: **Role Position:** {rolePosition}\n:white_small_square: **Managed:** {roleManaged}\n:white_small_square: **Hoisted:** {roleHoisted}\n:white_small_square: **Mentionable:** {roleMentionable}\n")
                            .WithColor(roleColor)
                            .AddInlineField($"Permissions ({rolePermissionsCount})", rolePermissionsString);

                        await ReplyAsync("", false, builder.Build());
                        return;
                    }
                }
                await ReplyAsync("No role with this name found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
