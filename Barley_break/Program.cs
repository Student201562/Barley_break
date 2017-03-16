using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Barley_break
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] returnInt = FileReader.ReadFromFile("C:\\Users\\Kiril\\OneDrive\\Документы\\Visual Studio 2015\\Projects\\Barley_break\\txt.txt");

            Console.Write("\tХотите ли вы сыграть? \n\t если да наберите Y \n\t если нет то любую клавишу = ");
            while (Convert.ToString(Console.ReadLine()) == "Y")
            {
                Game game = new Game(1,2,3,4,5,6,7,0,8);
                Console.Clear();
                Print.PrintGameField(game);

                    StartGame(game);

                //Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Вы выиграли!");
                Console.Write("Если вы хотите сыграть еще раз, намите Y = ");
            }

            Console.ReadKey();
        }

        static void StartGame(Game game)
        {
            while (!game.CheckWin())
            {
                Console.Write("\t\tВведите значение, которое хотите поменять = ");
                int moveValue = Convert.ToInt32(Console.ReadLine());

                Console.Clear();
                if (!game.Shift(moveValue))
                {
                    Console.WriteLine("\t\tНекорректные данные!!!");
                }
                Print.PrintGameField(game);
            }
        }
    }
}