using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FayKayBot.Modules
{
    public class RoleMembers : ModuleBase<SocketCommandContext>
    {
        [Command("rolemembers")]
        public async Task RolemembersAsync([Remainder] string name)
        {
            #region Variables
            var u = Context.Guild.Users;
            var roles = Context.Guild.Roles;
            bool roleExists = false;
            Color roleColor = Color.Red;
            int count = 0;
            #endregion

            foreach (var ro in roles)
            {
                if (ro.Name == name)
                {
                    roleExists = true;
                    roleColor = ro.Color;
                }
            }

            if (roleColor.ToString() == "#0")
            {
                roleColor = Color.LightGrey;
            }

            if (roleExists)
            {
                EmbedBuilder builder = new EmbedBuilder();

                builder.WithTitle($"Members of the {name} role")
                    .WithColor(roleColor);

                foreach (var v in u)
                {
                    foreach (var r in v.Roles)
                    {
                        if (r.Name == name)
                        {
                            builder.AddField(v.ToString(), v.Mention);
                            count++;
                        }
                    }

                    if (count >= 25)
                    {
                        await ReplyAsync("", false, builder.Build());
                        count = 0;
                        builder.Fields.Clear();
                    }
                }

                if (count > 0)
                {
                    await ReplyAsync("", false, builder.Build()); 
                }
            }
            else
            {
                await ReplyAsync("No role with this name found.");
            }
        }
    }
}
