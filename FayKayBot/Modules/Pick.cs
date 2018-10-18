using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FayKayBot.Modules
{
    public class Pick : ModuleBase<SocketCommandContext>
    {
        [Command("pick")]
        public async Task PickAsync([Remainder] string options)
        {
            #region Variables
            string[] arOptions = options.Split('|');
            Random rnd = new Random();
            int rng = rnd.Next(0, arOptions.Length);
            #endregion

            if (!options.Contains("|"))
            {
                await ReplyAsync("Please use '|' as a separator!");
                return;
            }

            await ReplyAsync($"I think the better option would be: **{arOptions[rng]}**");
        }
    }
}
