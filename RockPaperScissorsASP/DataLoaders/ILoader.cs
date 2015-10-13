﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsASP.DataLoaders
{
    public interface ILoader<T>
    {
        T Load(int id);
    }
}
