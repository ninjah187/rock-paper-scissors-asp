using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RockPaperScissorsASP.Models;

namespace RockPaperScissorsASP.DataLoaders
{
    public interface IModelLoader
    {
        IModelElement Load(int id);
    }
}
