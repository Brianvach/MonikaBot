using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MonikaBot.Modules
{
    public class Messages : ModuleBase<SocketCommandContext>
    {
        private int delay = 5000;

        [Command("delete")]
        [Summary("Delets x number of messages.")]
        [RequireUserPermission(Discord.GuildPermission.ManageMessages)]
        [RequireBotPermission(Discord.GuildPermission.ManageMessages)]
        public async Task Delete(uint count)
        {
            if (count < 1) return;
            var messages = await this.Context.Channel.GetMessagesAsync((int)count + 1).Flatten();


            await this.ReplyAsync("discord.remove(Messages)...");
            await Task.Delay(delay);
            await this.Context.Channel.DeleteMessagesAsync(messages);
            await this.ReplyAsync("messages successfully deleted");
            await Task.Delay(delay);
            messages = await this.Context.Channel.GetMessagesAsync(2).Flatten();
            await this.Context.Channel.DeleteMessagesAsync(messages);
        }
    }
}
