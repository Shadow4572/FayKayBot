using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FayKayBot.Modules
{
    public class BigText : ModuleBase<SocketCommandContext>
    {
        [Command("bigtext")]
        public async Task BigTextAsync([Remainder]string message)
        {
            #region Variables
            string messageString = "";
            #endregion

            #region Initializing variables
            foreach (var c in message)
            {
                switch (Char.ToLower(c))
                {
                    case ' ':
                        messageString = messageString + " ";
                        break;
                    case 'ß':
                        messageString = messageString + ":regional_indicator_s::regional_indicator_s:";
                        break;
                    case 'ä':
                        messageString = messageString + ":regional_indicator_a::regional_indicator_e:";
                        break;
                    case 'ü':
                        messageString = messageString + ":regional_indicator_u::regional_indicator_e:";
                        break;
                    case 'ö':
                        messageString = messageString + ":regional_indicator_o::regional_indicator_e:";
                        break;
                    case '0':
                        messageString = messageString + ":zero:";
                        break;
                    case '1':
                        messageString = messageString + ":one:";
                        break;
                    case '2':
                        messageString = messageString + ":two:";
                        break;
                    case '3':
                        messageString = messageString + ":three:";
                        break;
                    case '4':
                        messageString = messageString + ":four:";
                        break;
                    case '5':
                        messageString = messageString + ":five:";
                        break;
                    case '6':
                        messageString = messageString + ":six:";
                        break;
                    case '7':
                        messageString = messageString + ":seven:";
                        break;
                    case '8':
                        messageString = messageString + ":eight:";
                        break;
                    case '9':
                        messageString = messageString + ":nine:";
                        break;
                    case '+':
                        messageString = messageString + ":heavy_plus_sign:";
                        break;
                    case '-':
                        messageString = messageString + ":heavy_minus_sign:";
                        break;
                    case '*':
                        messageString = messageString + ":asterisk:";
                        break;
                    case '/':
                        messageString = messageString + ":heavy_division_sign:";
                        break;
                    case '#':
                        messageString = messageString + ":hash:";
                        break;
                    case '$':
                        messageString = messageString + ":heavy_dollar_sign:";
                        break;
                    default:
                        if (Char.IsLetter(c))
                        {
                            messageString = messageString + ":regional_indicator_" + Char.ToLower(c) + ":";
                        }
                        else
                        {
                            messageString = messageString + ":question:";
                        }
                        break;
                }

            }
            #endregion

            await ReplyAsync(messageString);
        }
    }
}
