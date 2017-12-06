﻿using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Inquisition.Data;
using System.Linq;
using System.Diagnostics;

namespace Inquisition.Modules
{
    [Group("start")]
    public class StartModule : ModuleBase<SocketCommandContext>
    {
        InquisitionContext db = new InquisitionContext();
        string Path = ProcessDictionary.Path;

        [Command("game")]
        [Summary("Starts up a game server")]
        public async Task StartGameAsync(string name)
        {
            Data.Game game = db.Games.Where(x => x.Name == name).FirstOrDefault();
            if (game is null)
            {
                await ReplyAsync(Message.Error.GameNotFound(game.Name));
                return;
            }

            try
            {
                if (ProcessDictionary.Instance.TryGetValue(game.Name, out Process temp))
                {
                    await ReplyAsync(Message.Error.GameAlreadyRunning(Context.User.Mention, game.Name, game.Version, game.Port));
                    return;
                }

                Process p = new Process();
                p.StartInfo.FileName = Path + game.Exe;
                p.StartInfo.Arguments = game.LaunchArgs;
                p.Start();

                ProcessDictionary.Instance.Add(game.Name, p);

                game.IsOnline = true;
                await db.SaveChangesAsync();

                await ReplyAsync(Message.Info.GameStartingUp(Context.User.Mention, game.Name, game.Version, game.Port));
            }
            catch (Exception ex)
            {
                await ReplyAsync(Message.Error.UnableToStartGameServer(game.Name));
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
