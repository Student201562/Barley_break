using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barley_break
{
    public class Print
    {
        // Вывод игрового поля
        public static void PrintGameField(Game game)
        {
            Console.Clear();
            Console.CursorTop = 3;

            for (int i = 0; i < game.gameField.GetLength(0); i++)
            {
                Console.Write("\t\t\t");
                for (int j = 0; j < game.gameField.GetLength(1); j++)
                {
                    if (game.gameField[i, j] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(game.gameField[i, j] + "\t");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(game.gameField[i, j] + "\t");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}