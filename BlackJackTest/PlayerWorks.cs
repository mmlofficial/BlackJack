using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackTest
{
    class PlayerWorks
    {
        public int Money { get; set; }
        private int Bet { get; set; }

        public PlayerWorks(int money)
        {
            if (!ErrorHandler.CheckMoney(money))
                this.Money = 0;
            else
                this.Money = money;
        }

        public bool Betting()
        {
            Console.WriteLine("Please make a bet to play a game...");
            int b;
            while(true)
            {
                try
                {
                    b = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong input! Try one more time...");
                }
            }
            if (ErrorHandler.CheckBet(b, this.Money))
            {
                this.Money -= b;
                this.Bet = b;
                return true;
            }
            else
                return false;
        }

        public int Insurancing()
        {
            if (!ErrorHandler.CheckInsurance(this.Bet, this.Money))
                return 0;
            Console.WriteLine("Do you want to take insurance?(y/n)");
            bool answer = Console.ReadLine() == "y" ? true : false;
            if (answer)
            {
                this.Money -= this.Bet;
                Console.WriteLine("You took an insurance!");
                return this.Bet;
            }
            return 0;
        }

        public int PlayerPart(PlayerHand playerHand, DeckWorks DW)//split if pair
        {
            int choice = 1;
            while (choice != 0)
            {
                Console.WriteLine(playerHand.ToString());
                switch(playerHand.GetStatus())
                {
                    case 1:
                        return 0;
                    case 2:
                        return 1;
                    case -1:
                        return -1;
                }
                if (choice == 2)
                    return 0;
                Console.WriteLine("--------------");
                Console.WriteLine("| 0 - Stand  |");
                Console.WriteLine("| 1 - Hit    |");
                if (ErrorHandler.CheckDouble(this.Bet, this.Money, playerHand.GetSize()))
                    Console.WriteLine("| 2 - Double |");
                Console.WriteLine("--------------");
                while (true)
                {
                    Console.WriteLine("Your choice : ");
                    try
                    {
                        choice = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Wrong input!");
                    }
                }
                if (choice == 1)
                    playerHand.AddCard(DW.PickCard());
                else if (choice == 2 && ErrorHandler.CheckDouble(this.Bet, this.Money, playerHand.GetSize()))
                {
                    this.Money -= this.Bet;
                    this.Bet += this.Bet;
                    playerHand.AddCard(DW.PickCard());
                }
            }
            return 0;
        }

        public void WinBlackjack()
        {
            this.Money += (int)(this.Bet * 3 / 2 + this.Bet);
            Console.WriteLine("Blackjack!!!");
        }

        public void Win()
        {
            this.Money += (int)(this.Bet * 2);
            Console.WriteLine("You win!");
        }

        public void Draw()
        {
            this.Money += this.Bet;
            Console.WriteLine("Draw!");

        }

        public void InsurancePayback(int Insurance)
        {
            this.Money += Insurance * 2;
            Console.WriteLine("Insurance payback");
        }
    }
}