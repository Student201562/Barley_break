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
            sp.Stream = MusicIndia.DiscordToday;
            sp.PlayLooping();
            sp.Play();
            //=========================
            Game game = new Game(5);    //("C:\\Users\\Kiril\\OneDrive\\Документы\\Visual Studio 2015\\Projects\\Barley_break\\txt.txt"
            //=========================
            sp.Stop();
            Console.ReadKey();
        }
    }
}