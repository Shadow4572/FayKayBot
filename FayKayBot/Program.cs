﻿using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace FayKayBot
{
    class Program
    {
        static void Main(string[] args) => new Program().RunBotAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;
        private bool loginsuccess = false;

        public async Task RunBotAsync()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();

            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .BuildServiceProvider();

            Console.Write("Please enter your token: ");
            string botToken = Console.ReadLine();

            // event subscriptions
            _client.Log += Log;

            await RegisterCommandAsync();

            while (!loginsuccess)
            {
                try
                {
                    await _client.LoginAsync(TokenType.Bot, botToken);
                    loginsuccess = true;
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("!!!Invalid token!!!");
                    Console.Write("Please enter your token: ");
                    botToken = Console.ReadLine();
                    loginsuccess = false;
                } 
            }

            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private Task Log(LogMessage arg)
        {
            Console.WriteLine(arg);

            return Task.CompletedTask;
        }

        public async Task RegisterCommandAsync()
        {
            _client.MessageReceived += HandleCommandAsync;

            await _commands.AddModulesAsync(Assembly.GetEntryAssembly());
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;

            if (message is null || message.Author.IsBot) return;

            int argPos = 0;

            if (message.HasStringPrefix("fay!", ref argPos) || message.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                var context = new SocketCommandContext(_client, message);

                var result = await _commands.ExecuteAsync(context, argPos, _services);

                if (!result.IsSuccess)
                {
                    Console.WriteLine($"{context.Message.Timestamp.LocalDateTime} - {context.Message.Author} tried: {context.Message}\nError: {result.ErrorReason}");
                }
                else
                {
                    Console.WriteLine($"{context.Message.Timestamp.LocalDateTime} - {context.Message.Author} posted: {context.Message}");
                }
            }
        }
    }
}
