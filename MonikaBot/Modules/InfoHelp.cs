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
                .WithThumbnailUrl("https://cdn.discordapp.com/attachments/245592511274287104/422147867655012355/Monika_Profile.PNG")
                .AddField("Help", "If you need help, please use the help command (<3help by default)")
                .AddInlineField("Author", "Brian Vach")
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
                .WithTitle("Help")
                .WithColor(Color.Green)
                .WithThumbnailUrl("")
                .AddField("help", "Where you are, provides command information")
                .AddField("info", "Provides information about the bot")
                .WithFooter("For additional help, please see the wiki.");

            await ReplyAsync("", false, build);
        }
    }
}
