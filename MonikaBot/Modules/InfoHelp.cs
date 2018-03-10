using Discord.Commands;
using Discord;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MonikaBot.Modules
{
    public class InfoHelp : ModuleBase<SocketCommandContext>
    {
        [Command("info")]
        public async Task Info()
        {
            EmbedBuilder build = new EmbedBuilder()
                .WithTitle("Monika Bot Info")
                .WithColor(Color.Green)
                .WithImageUrl("")
                .AddField("Help", "If you need help, please use the help command (<3help by default)")
                .AddField("Author", $"Project create by Brian Vach using Discord.NET")
                .AddField("GitHub", "https://github.com/Brianvach/MonikaBot")
                ;

            await ReplyAsync("", false, build);
        }

        [Command("help")]
        public async Task DefaulHelp()
        {

        }
    }
}
