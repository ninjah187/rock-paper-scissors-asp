using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RockPaperScissorsASP.Models;

namespace RockPaperScissorsASP
{
    public interface ISymbolToIconParser
    {
        // parses symbol and returns string e.g. glyphicon class name
        string Parse(Symbol? symbol);
    }
}
