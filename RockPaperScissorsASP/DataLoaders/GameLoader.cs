using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RockPaperScissorsASP.Models;

namespace RockPaperScissorsASP.DataLoaders
{
    public class GameLoader : ILoader<Game>
    {
        public Game Load(int it)
        {
            using (var context = new GameDbContext())
            {
                var game = context.Games
                    .Include(g => g.Player1)
                    .Include(g => g.Player2)
                    .Single();

                return game;
            }
        }
    }
}