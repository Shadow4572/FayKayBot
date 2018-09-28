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
        public async Task AvatarAsync(string user)
        {
            try
            {
                var u = Context.Guild.Users;

                foreach (var v in u)
                {
                    if (v.Username == user || v.Nickname == user)
                    {
                        await ReplyAsync(v.AvatarId);
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
