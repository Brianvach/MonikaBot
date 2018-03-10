using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MonikaBot.Modules
{
    class InfoHelp : ModuleBase<SocketCommandContext>
    {
        [Command("info")]
        public async Task Info()
        {
            
        }

        [Command("help")]
        public async Task DefaulHelp()
        {

        }
    }
}
