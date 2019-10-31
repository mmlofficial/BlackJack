using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding(1200);

            Game game = new Game(1, 52, 1000);
            while (game.Turn()) ;

            Console.WriteLine("End of the game!");
            Console.ReadKey();
                
        }
    }
}
