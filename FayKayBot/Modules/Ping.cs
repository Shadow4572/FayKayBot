using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FayKayBot.Modules
{
    public class Ping : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        public async Task PingAsync()
        {
            EmbedBuilder builder = new EmbedBuilder();

            builder.WithTitle("pong!")
                .WithDescription($":heartbeat: {Context.Client.Latency} ms")
                .WithColor(Color.Red);

            await ReplyAsync("", false, builder.Build());
        }
    }
}
