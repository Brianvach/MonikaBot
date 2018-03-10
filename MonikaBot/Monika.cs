using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MonikaBot
{
    class Monika
    {
        static void Main(string[] args) => new Monika().RunBotAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;
        
        private string prefix;

        public async Task RunBotAsync()
        {
            //load configuration information from file
            var filepath = "config.json";
            string BotToken = null;
            using (var r = new StreamReader(filepath))
            {
                var json = r.ReadToEnd();
                var jobj = JObject.Parse(json);
                BotToken = jobj.GetValue("token").ToString();
                this.prefix = jobj.GetValue("prefix").ToString();
            }

            //set up initial client paramaters
            _client = new DiscordSocketClient();
            _commands = new CommandService();

            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .BuildServiceProvider();
            

            //event subscriptions
            _client.Log += Log;

            await RegisterCommandsAsync();

            
            await _client.LoginAsync(Discord.TokenType.Bot, BotToken);

            await _client.StartAsync();

            await Task.Delay(-1);

        }

        

        private Task Log(LogMessage arg)
        {
            Console.WriteLine(arg);

            return Task.CompletedTask;
        }

        public async Task RegisterCommandsAsync()
        {
            _client.MessageReceived += HandledCommandAsync;

            await _commands.AddModulesAsync(Assembly.GetEntryAssembly());

        }

        private async Task HandledCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;

            if (message is null || message.Author.IsBot) return;

            int ArgPos = 0;

            if (message.HasStringPrefix(prefix, ref ArgPos) || message.HasMentionPrefix(_client.CurrentUser, ref ArgPos))
            {
                var context = new SocketCommandContext(_client, message);

                var result = await _commands.ExecuteAsync(context, ArgPos, _services);

                if (!result.IsSuccess)
                    Console.WriteLine(result.ErrorReason);
            }
        }
    }
}
