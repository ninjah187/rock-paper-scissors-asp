using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using RockPaperScissorsASP.DataLoaders;
using RockPaperScissorsASP.Models;
using RockPaperScissorsASP.UrlGeneration;

namespace RockPaperScissorsASP.Controllers
{
    public class GameController : Controller
    {
        private readonly ILoader<Game> _gameLoader = new GameLoader();

        // saves chosenSymbol into session state and returns partial view with asking for name form
        public ActionResult AskName(int gameId, Symbol chosenSymbol)
        {
            Session["ChosenSymbol"] = chosenSymbol;
            ViewBag.GameId = gameId;

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

        public ActionResult Submit(int id, string name)
        {
            var symbol = (Symbol) Session["ChosenSymbol"];

            var player = new Player()
            {
                Name = name,
                Symbol = symbol
            };
            
            using (var context = new GameDbContext())
            {
                var game = context.Games
                    .Include(g => g.Player1)
                    .Include(g => g.Player2)
                    .SingleOrDefault(g => g.Id == id);

                if (game == null)
                {
                    game = new Game();
                    game.Player1 = player;

                    // TODO: przemyśl czy:
                    // TODO: - powinieneś trzymać referencję do DataLoader w tym obiekcie, czy tworzyć każdorazowo, gdy jest potrzebny
                    // TODO: - jw. z BasicUrlGenerator
                    
                    context.Players.Add(player);
                    context.Games.Add(game);
                    context.SaveChanges();

                    var urlGenerator = new BasicUrlGenerator();
                    game.RefLink = urlGenerator.GetUrl(game.Id);

                    context.SaveChanges();

                    return PartialView("Create", game);
                }
                else
                {
                    game.Player2 = player;

                    context.Players.Add(player);
                    context.SaveChanges();

                    return PartialView("ShowPartial", game);
                }
            }
        }

        public ActionResult Show(int id)
        {
            return View(_gameLoader.Load(id));
        }

        //public ActionResult Show(string refLink)
        //{
        //    return View(((GameLoader)_gameLoader).Load(refLink));
        //}

        public ActionResult ShowPartial(int id)
        {
            return PartialView("Show", _gameLoader.Load(id));
        }

        public ActionResult Play(int id = -1)
        {
            var g = _gameLoader.Load(id);

            if (g != null && g.Player2 != null)
            {
                return RedirectToAction("Show", new { id = id });
            }
            
            return View("Play", g);
        }
    }
}