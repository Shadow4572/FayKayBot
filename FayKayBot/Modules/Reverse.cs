using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FayKayBot.Modules
{
    public class Reverse : ModuleBase<SocketCommandContext>
    {
        [Command("reverse")]
        public async Task ReverseAsync([Remainder] string message)
        {
            #region Variables
            var reversedMessage = message.Reverse();
            string reversedMessageString = "";
            #endregion

            #region Initializing variables
            foreach (var m in reversedMessage)
            {
                reversedMessageString = reversedMessageString + m.ToString();
            }
            #endregion

            await Context.Message.DeleteAsync();
            await ReplyAsync($"{reversedMessageString}\n*Reversed by {Context.Message.Author.Mention}*");
        }
    }
}
