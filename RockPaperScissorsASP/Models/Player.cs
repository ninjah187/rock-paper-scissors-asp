using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RockPaperScissorsASP.Models
{
    public class Player : IModelElement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Symbol? Symbol { get; set; }
    }
}