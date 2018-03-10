using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MonikaBot.Modules
{
    public class Prefix : ModuleBase<SocketCommandContext>
    {
        [Command("prefix"), RequireUserPermission(Discord.GuildPermission.Administrator)]
        public async Task ResetPrefixAsync(string NewPrefix = "<3")
        {

        }
    }
}
