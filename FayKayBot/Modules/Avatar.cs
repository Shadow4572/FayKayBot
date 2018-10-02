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
        public async Task AvatarAsync(params string[] list)
        {
            try
            {
                Console.WriteLine("test");

                string command = Context.Message.ToString();
                string[] splittedCommand = command.Split(' ');
                int commadLength = splittedCommand.Length;

                string user = "";
                string nick = "";

                for (int i = 1; i < commadLength; i++)
                {
                    user = user + splittedCommand[i];
                }

                for (int i = 1; i < commadLength; i++)
                {
                    nick = nick + splittedCommand[i] + " ";
                }

                nick = nick.Trim();

                Console.WriteLine(user);
                Console.WriteLine(nick);

                var u = Context.Guild.Users;

                foreach (var v in u)
                {
                    string username = v.Username.Replace(" ", string.Empty);
                    string nickname = v.Nickname;

                    if (username == user || nickname == nick)
                    {
                        string avatarLink = v.GetAvatarUrl();
                        string linkFirst = avatarLink.Split('=').First();
                        string linkLast = avatarLink.Split('=').Last();
                        linkLast = "1024";
                        avatarLink = linkFirst + "=" + linkLast;

                        await ReplyAsync(avatarLink);
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
