﻿using Discord;
using Discord.WebSocket;

namespace Inquisition.Data
{
    public class EmbedTemplate
    {
        public static EmbedBuilder Create(SocketSelfUser author, SocketUser user)
        {
            EmbedBuilder embed = new EmbedBuilder();
            embed = new EmbedBuilder();
            embed.WithCurrentTimestamp();
            embed.WithColor(Color.Blue);
            embed.WithAuthor(author);
            embed.WithFooter($"Requested by: {user}", user.GetAvatarUrl());

            return embed;
        }
    }
}
