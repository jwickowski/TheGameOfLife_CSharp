using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGameOfLife.Core;

namespace Vizualizer
{
   public class Painter
    {
       public static void Paint(Board board)
       {
            Console.Clear();
            for (var x = 0; x < board.Width; x++)
            {
                for (var y = 0; y < board.Height; y++)
                {
                   Console.Write(board.IsAlive(x,y)? "X" : " ");
                }
                Console.WriteLine();
            }
        }
    }
}
