using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BlackJackTest
{
    class ErrorHandler
    {
        public static bool CheckMoney(int money)
        {
            if (money <= 0)
            {
                Console.WriteLine("You spent all your money((");
                return false;
            }
            return true;
        }

        public static bool CheckBet(int bet, int money)
        {
            if (bet > money)
            {
                Console.WriteLine("You dont have enough money to make this bet(");
                return false;
            }
            else if (bet < 1)
            {
                Console.WriteLine("Minimum bet is 1$");
                return false;
            }
            else
                return true;
        }

        public static bool CheckInsurance(int bet, int money)
        {
            if (bet > money)
            {
                Console.WriteLine("You dont have enough money to make insurance");
                return false;
            }
            return true;
        }

        public static bool CheckDouble(int bet, int money, int count)
        {
            if (bet > money || count != 2)
            {
                return false;
            }
            return true;
        }

        public static int CheckWin(int playerScore, int dealerScore)
        {
            if (playerScore > dealerScore)
                return 1;

            else if (playerScore < dealerScore)
            {
                Console.WriteLine("Dealer has more points.\nYou lose!"); //
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}