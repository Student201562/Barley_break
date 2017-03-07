using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barley_break
{
    class Program
    {
        static void Main(string[] args)
        {
            Random gen = new Random();
            Game game = new Game(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0);
            int valueWhichEnterUser = 0;

            game.Print();
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("Перемешать? (да/нет)");
            if (Convert.ToString(Console.ReadLine()) == "да")
            {
                game.GenerationNumbersOnField(gen);

                Console.Clear();

                int moveValue = 0;
                while (!(game.CheckWin() == true))
                {
                    game.Print();
                    Console.Write("\t\tВведите число, которое хотите поменять = ");
                    try
                    {
                        moveValue = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        moveValue = Convert.ToInt32(Console.ReadLine());
                    }
                    game.GetLocation(moveValue);
                    game.Shift(valueWhichEnterUser);
                    Console.Clear();
                }
            }
            else
            {
                Console.WriteLine("Ну,ладно:(");
            }
            Console.ReadKey();
        }
    }
}
