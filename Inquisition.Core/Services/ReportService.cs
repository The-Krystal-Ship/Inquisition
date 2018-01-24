﻿using Discord;
using Discord.Commands;
using Discord.WebSocket;

using Inquisition.Core.Handlers;
using Inquisition.Data.Handlers;
using Inquisition.Data.Models;

using System;
using System.Threading.Tasks;

namespace Inquisition.Core.Services
{
	public class ReportService
	{
		// CommandService.ExecuteAsync errors
		public static async Task Report(string e, SocketMessage msg)
		{
			try
			{
				EmbedBuilder embed = EmbedHandler
					.Create()
					.WithColor(Color.DarkRed);

				embed.WithTitle("Error ocurred");
				embed.WithDescription(e);

				await msg.Channel.SendMessageAsync("Oops...", false, embed);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}

		// Warning
		public static void Report(Exception e)
		{
			Report report = new Report
			{
				Severity = Severity.Warning,
				Type = Data.Models.Type.General,
				ErrorMessage = e.Message,
				StackTrace = e.StackTrace
			};

			FillInnerExceptions(ref report, e);

			LogHandler.GenerateLog(ref report);
			Console.WriteLine($"Unexpected error ocurred, a log file has been created.");
		}

		// Critical
        public static void Report(SocketCommandContext ctx, Exception e)
        {
			Report report = new Report
			{
				Severity = Severity.Critical,
				Type = Data.Models.Type.Guild,
				Channel = ctx.Channel.Name,
				ErrorMessage = e.Message,
				Message = ctx.Message.Content.Replace("<@304353122019704842> ", ""),
				GuildID = ctx.Guild.Id.ToString(),
				GuildName = ctx.Guild.Name,
				StackTrace = e.StackTrace.Trim().Replace("<", "").Replace(">", "").Replace("&", ""),
				UserID = ctx.User.Id.ToString(),
				UserName = ctx.User.Username
			};

			FillInnerExceptions(ref report, e);

			LogHandler.GenerateLog(ref report);
			EmailHandler.Send(report);
        }

		private static void FillInnerExceptions(ref Report report, Exception e)
		{
			while (e.InnerException != null)
			{
				e = e.InnerException;
				report.InnerExceptions.Add(new Report()
				{
					Severity = Severity.Critical,
					Type = Data.Models.Type.Inner,
					ErrorMessage = e.Message,
					StackTrace = e.StackTrace.Trim().Replace("<", "").Replace(">", "").Replace("&", "")
				});
			}
		}
	}
}
