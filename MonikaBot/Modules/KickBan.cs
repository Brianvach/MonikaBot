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
            await user.KickAsync(reason);
        }

        [Command("delete")]
        [RequireUserPermission(Discord.GuildPermission.BanMembers)]
        [RequireBotPermission(Discord.GuildPermission.BanMembers)]
        public async Task BanAsync(IGuildUser user, [Remainder] string reason = "You will never be good enough for him")
        {
            await ReplyAsync($"discord.erase('{user.Username}.chr')");
            await Context.Guild.AddBanAsync(user, 7, reason);
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
