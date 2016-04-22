using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tgol.App;
using TheGameOfLife.Core;
using Vizualizer;

namespace TheGameOfLife.Visualisation
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new bool[20, 20];
            input[1, 0] = true;

            input[0, 2] = true;
            input[1, 2] = true;
            input[2, 2] = true;
            input[2, 1] = true;

            input[8, 0] = true;
            input[8, 1] = true;
            input[8, 2] = true;
            input[9, 1] = true;
            input[9, 2] = true;
            input[9, 3] = true;



            input[6, 11] = true;
            input[7, 11] = true;
            input[8, 11] = true;
            //input[9, 11] = true;
            //input[10, 11] = true;
            //input[11, 11] = true;
            input[12, 11] = true;
            input[13, 11] = true;
            input[14, 11] = true;
            //input[15, 11] = true;


            Board board = new BoardArrayImp(input);
            var game = new LifeGame(board);


            while (true)
            {
                Painter.Paint(board);
                board = game.NextRound();
                //Thread.Sleep(200);
                Console.ReadLine();

            }
            Console.ReadLine();
        }
    }
}
