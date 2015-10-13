using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RockPaperScissorsASP.DataLoaders;
using RockPaperScissorsASP.Models;

namespace RockPaperScissorsASP.Controllers
{
    public class GameController : Controller
    {
        private readonly ILoader<Game> _gameLoader = new GameLoader();

        // saves chosenSymbol into session state and returns partial view with asking for name form
        public ActionResult AskName(Symbol chosenSymbol)
        {
            Session["ChosenSymbol"] = chosenSymbol;

            return PartialView(chosenSymbol);
        }

        // saves new Game object in database and returns partial view with info about game and links for opponent
        public ActionResult Create(string name)
        {
            // TODO: create fail view when there is no chosenSymbol in session state
            var symbol = (Symbol) Session["ChosenSymbol"];

            var player = new Player()
            {
                Name = name,
                Symbol = symbol
            };

            var game = new Game()
            {
                Player1 = player,
                Player2 = null
            };

            using (var context = new GameDbContext())
            {
                context.Players.Add(player);
                context.Games.Add(game);
                context.SaveChanges();
            }

            return PartialView(game);
        }

        public ActionResult Show(int id)
        {
            return View(_gameLoader.Load(id));
        }

        public ActionResult Play(int id)
        {
            return View(_gameLoader.Load(id));
        }
    }
}