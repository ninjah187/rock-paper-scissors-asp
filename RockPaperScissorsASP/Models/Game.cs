using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RockPaperScissorsASP.Models
{
    public class Game : IModelElement
    {
        public int Id { get; set; }
        
        public virtual Player Player1 { get; set; }
        public virtual Player Player2 { get; set; }
    }
}