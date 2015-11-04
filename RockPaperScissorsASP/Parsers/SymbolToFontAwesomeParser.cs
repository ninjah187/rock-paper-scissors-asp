using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RockPaperScissorsASP.Models;

namespace RockPaperScissorsASP.Parsers
{
    public class SymbolToFontAwesomeParser : ISymbolToIconParser
    {
        public string Parse(Symbol? symbol)
        {
            if (symbol == null)
            {
                throw new ArgumentNullException("symbol", "Symbol value is null.");
            }

            var className = "fa fa-";

            switch (symbol.Value)
            {
                case Symbol.Rock:
                    className += "hand-rock-o";
                    break;

                case Symbol.Paper:
                    className += "hand-paper-o";
                    break;

                case Symbol.Scissors: 
                    className += "hand-scissors-o";
                    break;

                default:
                    throw new InvalidOperationException("Unknown symbol value.");
            }

            return className;
        }
    }
}