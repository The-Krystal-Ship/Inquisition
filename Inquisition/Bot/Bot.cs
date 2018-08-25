﻿using Discord;
using Discord.WebSocket;

using System.Threading.Tasks;

using TheKrystalShip.Inquisition.Extensions;
using TheKrystalShip.Inquisition.Handlers;
using TheKrystalShip.Inquisition.Properties;

namespace TheKrystalShip.Inquisition
{
    public class Bot
    {
        private readonly DiscordSocketClient _client;
        private readonly CommandHandler _commandHandler;
        private readonly string _token;

        public Bot()
        {
            _client = new DiscordSocketClient(new DiscordSocketConfig()
                {
                    LogLevel = LogSeverity.Debug,
                    DefaultRetryMode = RetryMode.AlwaysRetry,
                    ConnectionTimeout = 5000,
                    AlwaysDownloadUsers = true
                }
            );

            _commandHandler = new CommandHandler(ref _client);

            _token = Settings.Instance.GetToken();
        }

        public async Task InitAsync()
        {
            await _client.LoginAsync(TokenType.Bot, _token);
            await _client.StartAsync();
            await _client.SetGameAsync("God");
        }
    }
}
