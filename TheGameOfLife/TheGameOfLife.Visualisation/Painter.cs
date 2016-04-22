using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizualizer
{
   public class Painter
    {
       public static void Paint(bool[,] array)
       {
            Console.Clear();
            for (var x = 0; x < array.GetLength(0); x++)
            {
                for (var y = 0; y < array.GetLength(1); y++)
                {
                   Console.Write(array[x,y]? "X" : " ");
                }
                Console.WriteLine();
            }
        }
    }
}
