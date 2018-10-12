using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FayKayBot.Modules
{
    public class Help : ModuleBase<SocketCommandContext>
    {
        [Command("help")]
        public async Task HelpAsync()
        {
            #region Variables
            // getting all the commands
            CommandService _commands = new CommandService();
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly());

            // other variables
            var allCommands = _commands.Commands;
            string allCommandsString = "";
            #endregion

            #region Initializing variables
            foreach (var cmd in allCommands)
            {
                if (cmd.Name == allCommands.Last().Name)
                {
                    allCommandsString = allCommandsString + $"``{cmd.Name}``";
                }
                else
                {
                    allCommandsString = allCommandsString + $"``{cmd.Name}``, ";
                }
            }
            #endregion

            EmbedBuilder builder = new EmbedBuilder();

            builder.WithTitle("FayKay Help")
                .WithColor(Color.Red)
                .AddInlineField("All commands", allCommandsString);

            await ReplyAsync("", false, builder.Build());
        }
    }
}
