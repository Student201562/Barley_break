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
            Game game = new Game(1, 2, 3, 4, 5, 6, 7, 8, 0);
            int valueWhichEnterUser = 0;

            game.GenerationNumbersOnField(gen);
            int moveValue = 0;
            Console.WriteLine("Если вам надоест играть наберите 1000");
            while (!(game.CheckWin() == true))
            {
                game.Print();
                        Console.Write("Введите число, которое хотите поменять");
                        moveValue = Convert.ToInt32(Console.ReadLine());
                game.GetLocation(moveValue);
                game.Shift(valueWhichEnterUser);
                Console.Clear();


            }
            Console.ReadKey();
        }
    }
}
