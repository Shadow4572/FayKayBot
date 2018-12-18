using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FayKayBot.Modules
{
    public class Say : ModuleBase<SocketCommandContext>
    {
        [Command("say")]
        public async Task SayAsync([Remainder]string content)
        {
            await ReplyAsync(content);
        }
    }
}
