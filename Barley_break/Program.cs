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
            try
            {
                //int[] returnInt = FileReader.ReadFromFile("C:\\Users\\Kiril\\OneDrive\\Документы\\Visual Studio 2015\\Projects\\Barley_break\\txt.txt");
                Game game = new Game(1,2,3,0);
                Print.PrintGameField(game);
                while (!game.CheckWin())
                {
                    Console.Write("\t\tВведите значение, которое хотите поменять = ");
                    int moveValue = Convert.ToInt32(Console.ReadLine());
                    while (game.Shift(moveValue) == false)
                    {
                        Print.PrintGameField(game);
                        Console.Write("\t\tВведите значение, которое хотите поменять = ");
                        moveValue = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                    }
                    Print.PrintGameField(game);
                    
                    //Console.WriteLine(game[2, 2]);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Игра не может быть создана");
            }
            Console.ReadKey();
        }
    }
}