﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tgol.App;

namespace TheGameOfLife.Core.Tests
{
    public class BoardArrayImpTest : BoardTest
    {
        protected override Board GetBoardFromArray(bool[,] array)
        {
            return new BoardArrayImp(array);
        }
    }
}
