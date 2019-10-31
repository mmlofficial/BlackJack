using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackTest
{
    class CardVariables
    {
        private static Dictionary<string, int> Dcost = new Dictionary<string, int>
        {
            {"2", 2}, {"3", 3}, {"4", 4},{"5", 5},
            {"6", 6},{"7", 7},{"8", 8},{"9", 9},
            {"10", 10},{"J", 10},{"Q", 10},{"K", 10}, {"A", 11}
        };

        public static string[] Value = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
        //public int len = Value.Length;

        public static string Spades()
        {
            return "♠";
        }
        public static string Hearts()
        {
            return "♥";
        }
        public static string Diamonds()
        {
            return "♦";
        }
        public static string Clubs()
        {
            return "♣";
        }

        public static int GetDcost(string value)
        {
            return Dcost[value];
        }

    }
}
