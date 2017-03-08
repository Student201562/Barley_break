using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barley_break
{
    internal class Print
    {
        public static void PrintData(int[,] gameField)
        {
            Console.CursorTop = 3;

            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                Console.Write("\t\t\t");
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    if (gameField[i, j] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    Console.Write(gameField[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
