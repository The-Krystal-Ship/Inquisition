﻿using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Inquisition.Data;
using Inquisition.Properties;
using System;
using System.Threading.Tasks;

namespace Inquisition.Services
{
    public class ExceptionService
    {
        private static DiscordSocketClient client;
        private static SocketUser Heisenberg;

        public ExceptionService(DiscordSocketClient socketClient)
        {
            client = socketClient;
        }

        public static async Task SendErrorAsync(string e)
        {
            try
            {
                Heisenberg = client.GetUser(Convert.ToUInt64(Res.HeisenbergID));
                EmbedBuilder embed = EmbedTemplate
                    .Create()
                    .WithColor(Color.DarkRed);

                embed.WithTitle("Error ocurred:");
                embed.WithDescription(e);

                await Heisenberg.SendMessageAsync("Oops...", false, embed);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static async Task SendErrorAsync(SocketCommandContext context, string e)
        {
            try
            {
                Heisenberg = client.GetUser(Convert.ToUInt64(Res.HeisenbergID));
                EmbedBuilder embed = EmbedTemplate
                    .Create()
                    .WithColor(Color.DarkRed);

                SocketUserMessage msg = context.Message;

                embed.WithTitle("Error ocurred:");
                embed.WithDescription(
                    $"{e}\n\n" +
                    $"Caused by:\n" +
                    $"*{msg.Content}*");
                embed.WithFooter($"{msg.Author}", msg.Author.GetAvatarUrl());

                await context.Channel.SendMessageAsync("Oops...", false, embed);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static async Task SendErrorAsync(Exception e)
        {
            try
            {
                Heisenberg = client.GetUser(Convert.ToUInt64(Res.HeisenbergID));
                string em = e.ToString();
                EmbedBuilder embed = EmbedTemplate
                    .Create()
                    .WithColor(Color.DarkRed);

                embed.WithTitle("Error:");
                embed.WithDescription(em);

                await Heisenberg.SendMessageAsync("Oops...", false, embed);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static async Task SendErrorAsync(string e, SocketMessage msg)
        {
            try
            {
                Heisenberg = client.GetUser(Convert.ToUInt64(Res.HeisenbergID));
                EmbedBuilder embed = EmbedTemplate
                    .Create(client.CurrentUser)
                    .WithColor(Color.DarkRed);

                embed.WithTitle($"Error:");
                embed.WithDescription(
                    $"{e}\n\n" +
                    $"Caused by:\n" +
                    $"*{msg.Content}*");
                embed.WithFooter($"{msg.Author}", msg.Author.GetAvatarUrl());

                await msg.Channel.SendMessageAsync("Oops...", false, embed);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static async Task SendErrorAsync(SocketCommandContext context, Exception e)
        {
            try
            {
                Heisenberg = client.GetUser(Convert.ToUInt64(Res.HeisenbergID));
                string em = e.ToString();
                EmbedBuilder embed = EmbedTemplate
                    .Create()
                    .WithColor(Color.DarkRed)
                    .WithTitle("Error ocurred:")
                    .WithDescription($"**INFO ABOUT COMMAND**\n" +
                                     $"**Guild Name:**\t{context.Guild.Name}\n" +
                                     $"**Guild ID:**\t{context.Guild.Id}\n" +
                                     $"**User:**\t{context.User.Username}#{context.User.Discriminator}\n\n" +
                                     $"**Message:**\n" +
                                     $"{context.Message.Content}\n\n" +
                                     $"**Error:**\n{em}");

                await context.Channel.SendMessageAsync("Oops...", false, embed);
                await Heisenberg.SendMessageAsync("Oops...", false, embed);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}