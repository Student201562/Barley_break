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
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
            sp.Stream = MusicIIndia.DiscordToday;
            sp.PlayLooping();
            sp.Play();
            //=========================
            Random gen = new Random();
            Game game = new Game(3);

            int valueWhichEnterUser = 0;
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("Перемешать? (да/нет)");
            if (Convert.ToString(Console.ReadLine()) == "да")
            {
                game.GenerationNumbersOnField(gen);

                Console.Clear();

                int moveValue = 0;
                while (!(game.CheckWin() == true))
                {
                    Console.Write("\n\t\tВведите число, которое хотите поменять = ");
                    Console.ForegroundColor = ConsoleColor.Blue;
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
            //=========================
            sp.Stop();
            //=========================
            Console.ReadKey();
        }
    }
}
