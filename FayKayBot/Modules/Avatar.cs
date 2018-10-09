using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FayKayBot.Modules
{
    public class Avatar : ModuleBase<SocketCommandContext>
    {
        [Command("avatar")]
        public async Task AvatarAsync([Remainder] string name)
        {
            try
            {
                var u = Context.Guild.Users;

                foreach (var v in u)
                {
                    if (v.Username == name || v.Nickname == name)
                    {
                        string avatarLink = v.GetAvatarUrl();
                        string linkFirst = avatarLink.Split('=').First();
                        string linkLast = avatarLink.Split('=').Last();
                        linkLast = "1024";
                        avatarLink = linkFirst + "=" + linkLast;

                        EmbedBuilder builder = new EmbedBuilder();

                        builder.WithTitle($"Avatar of {name}")
                            .WithImageUrl(avatarLink)
                            .WithUrl(avatarLink)
                            .WithColor(Color.Red);

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
