using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barley_break
{
    public static class Print
    {
        // Вывод игрового поля
        public static void PrintGameField(Game game)
        {
            Console.CursorTop = 2;

            for (int i = 0; i < game.sizeField; i++)
            {
                Console.Write("\t\t\t");
                for (int j = 0; j < game.sizeField; j++)
                {
                    if (game[i, j] == 0)
                    {
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(game[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("|" +  "\t");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write( "|" + game[i, j] + "|" + "\t");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}