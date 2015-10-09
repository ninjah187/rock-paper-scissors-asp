using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RockPaperScissorsASP.Models;

namespace RockPaperScissorsASP.Controllers
{
    public class GameController : Controller
    {
        // saves chosenSymbol into session state and returns partial view with asking for name form
        public ActionResult AskName(Symbol chosenSymbol)
        {
            Session["ChosenSymbol"] = chosenSymbol;

            return PartialView(chosenSymbol);
        }

        public ActionResult NewGame()
        {
            throw new NotImplementedException();
        }
    }
}