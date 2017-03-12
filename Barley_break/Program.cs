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
            //System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
            //sp.Stream = MusicIndia.DiscordToday;
            //sp.PlayLooping();
            //sp.Play();
            //========================
            int numEnterUser = 0;
            do
            {Console.Clear();
                do
                {
                    Print.PrintNumberWhichEnterUser();
                    int.TryParse(Console.ReadLine(), out numEnterUser);
                    if (numEnterUser > 1)
                    {
                        Game game = new Game(numEnterUser);
                        //("C:\\Users\\Kiril\\OneDrive\\Документы\\Visual Studio 2015\\Projects\\Barley_break\\txt.txt")
                    }
                    else
                    {
                        Print.PrintError();
                        //
                        //throw new Exception("Число не соответствует игровому полю");
                    }
                } while (numEnterUser <= 1);
                Console.Clear();
                Console.Write("Если хотите сыграть еще раз нажмите y/n = ");
            } while (Convert.ToString(Console.ReadLine()) == "y"); 
            //========================
            //sp.Stop();
            Console.ReadKey();
        }
    }
}