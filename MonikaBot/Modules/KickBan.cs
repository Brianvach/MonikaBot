using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Discord;
using Discord.WebSocket;

namespace MonikaBot.Modules
{
    public class KickBan : ModuleBase<SocketCommandContext>
    {
        [Command("kick")]
        [RequireUserPermission(Discord.GuildPermission.KickMembers)]
        [RequireBotPermission(Discord.GuildPermission.KickMembers)]
        public async Task KickAsync(IGuildUser user, [Remainder] string reason = "You will never be good enough for him")
        {
            await ReplyAsync($"discord.remove('{user.Username}.chr')");
            EmbedBuilder build = new EmbedBuilder()
                .WithTitle("Removed")
                .WithColor(Color.Red)
                .WithThumbnailUrl("https://cdn.discordapp.com/attachments/422194940471148566/422460677031067649/Monika_Sad.png")
                .WithDescription("You were kicked from the server")
                .AddField("Server", Context.Guild.Name)
                .AddField("Reason", reason)
                ;
            await user.SendMessageAsync("", false, build);
            await user.KickAsync(reason);
        }

        [Command("ban")]
        [RequireUserPermission(Discord.GuildPermission.BanMembers)]
        [RequireBotPermission(Discord.GuildPermission.BanMembers)]
        public async Task BanAsync(IGuildUser user, [Remainder] string reason = "You will never be good enough for him")
        {
            await ReplyAsync($"discord.erase('{user.Username}.chr')");
            EmbedBuilder build = new EmbedBuilder()
                .WithTitle("Deleted")
                .WithColor(Color.Red)
                .WithThumbnailUrl("https://cdn.discordapp.com/attachments/422194940471148566/422460677031067649/Monika_Sad.png")
                .WithDescription("You were banned from the server")
                .AddField("Server", Context.Guild.Name)
                .AddField("Reason", reason)
                ;
            await user.SendMessageAsync("", false, build);
            await Context.Guild.AddBanAsync(user, 0, reason);
        }

        [Command("restore")]
        [RequireUserPermission(Discord.GuildPermission.BanMembers)]
        [RequireBotPermission(Discord.GuildPermission.BanMembers)]
        public async Task UnBanAsync(IGuildUser user)
        {
            await ReplyAsync($"discord.restore('{user.Username}.chr')");
            await Context.Guild.RemoveBanAsync(user);
        }
    }
}
