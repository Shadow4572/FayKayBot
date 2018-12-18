using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FayKayBot.Modules
{
    public class SayD : ModuleBase<SocketCommandContext>
    {
        [Command("sayd")]
        public async Task SayDAsync([Remainder]string content)
        {
            await Context.Message.DeleteAsync();
            await ReplyAsync(content);
        }
    }
}
