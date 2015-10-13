using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RockPaperScissorsASP.Models;

namespace RockPaperScissorsASP
{
    public class SymbolToGlyphIconParser : ISymbolToIconParser
    {
        public string Parse(Symbol? symbol)
        {
            if (symbol == null)
            {
                throw new ArgumentNullException("symbol", "Symbol value is null.");
            }

            var className = "glyphicon glyphicon-";

            switch (symbol.Value)
            {
                case Symbol.Rock:
                    className += "cloud";
                    break;

                case Symbol.Paper:
                    className += "duplicate";
                    break;

                case Symbol.Scissors:
                    className += "scissors";
                    break;

                default:
                    throw new InvalidOperationException("Uknown symbol value.");
            }

            return className;
        }
    }
}