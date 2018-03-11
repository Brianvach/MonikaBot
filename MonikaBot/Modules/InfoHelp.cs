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
                .WithThumbnailUrl("https://cdn.discordapp.com/attachments/422194940471148566/422195002307772417/Monika_Profile.png")
                .AddField("Help", "If you need help, please use the help command (<3help by default)")
                .AddInlineField("Author", "Brian Vach\nVoytrekk#5866")
                .AddInlineField("Version", "Monika: 0.1\nDiscord.Net: 1.0.2")
                .AddField("GitHub", "https://github.com/Brianvach/MonikaBot")
                .WithFooter($"I will always love you {Context.User.Username}!")
                ;

            await ReplyAsync("", false, build);
        }

        [Command("help")]
        public async Task DefaulHelp()
        {
            EmbedBuilder build = new EmbedBuilder()
                .WithTitle("I'll do whatever I can to help you!")
                .WithColor(Color.Green)
                .WithThumbnailUrl("https://cdn.discordapp.com/attachments/422194940471148566/422213724368142357/Monika_Quizicle.png")
                .AddField("Commands", "See a full list of commands on the [wiki](https://github.com/Brianvach/MonikaBot/wiki/Commands)")
                .WithFooter("For additional help, please see the [wiki](https://github.com/Brianvach/MonikaBot/wiki).");

            await ReplyAsync("", false, build);
        }
    }
}
