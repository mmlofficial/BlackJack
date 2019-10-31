using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackTest
{
    class Game
    {
        DeckWorks DW;
        PlayerWorks PW;
        private int Insurance;

        public Game(int decknum, int size, int player_money)
        {
            this.DW = new DeckWorks(decknum, size);
            this.PW = new PlayerWorks(player_money);
            this.Insurance = 0;
        }

        public bool Turn()
        {
            if (!ErrorHandler.CheckMoney(this.PW.Money))
                return false;
            if (!this.PW.Betting())
                return false;
            DealerHand dealerHand = new DealerHand(DW.PickCard());
            Console.WriteLine(dealerHand.ToString());
            PlayerHand playerHand = new PlayerHand(DW.PickCard(), DW.PickCard());
            if (dealerHand[0].getValue() == "A")
            {
                this.Insurance = PW.Insurancing();
            }
            int ko = PW.PlayerPart(playerHand, DW);
            switch (ko) //for debugging
            {
                case -1:
                    Console.WriteLine("Ohhh... Bust!");
                    Console.WriteLine("End of turn(P).(Bust)");
                    Console.WriteLine(PW.Money.ToString());
                    return true;
                case 1:
                    Console.WriteLine("End of turn(P).(Blackjack)");
                    PW.WinBlackjack();
                    Console.WriteLine(PW.Money.ToString());
                    return true;
                default:
                    break;
            }

            ko = this.DealerPart(dealerHand, DW);
            switch (ko) //for debugging
            {
                case -1:
                    Console.WriteLine("Dealer bust!");
                    Console.WriteLine("End of turn(D).(Bust)");
                    PW.Win();
                    break;
                case 3:
                    Console.WriteLine("End of turn(D).(Insurance)");
                    PW.InsurancePayback(this.Insurance);
                    break;
                case 2:
                    Console.WriteLine("Dealer has a blackjack!");
                    Console.WriteLine("You lose!");
                    Console.WriteLine("End of turn(D).(Blackjack)");
                    break;
                default:
                    int err = ErrorHandler.CheckWin(playerHand.GetScore(), dealerHand.GetScore());
                    if (err == 1)
                        PW.Win();
                    else if (err == 0)
                        PW.Draw();
                    break;
            }
            Console.WriteLine(PW.Money.ToString());
            Console.WriteLine(DW.ToString());
            return true;

        }
        private int DealerPart(DealerHand dealerHand, DeckWorks DW)
        {
            if (this.Insurance != 0)
            {
                dealerHand.AddCard(DW.PickCard());
                if (dealerHand.GetStatus() == 2)
                    return 3;
            }

            while (true)
            {
                Console.WriteLine(dealerHand.ToString());
                if (dealerHand.GetScore() < 17)
                    dealerHand.AddCard(DW.PickCard());
                else
                    break;
            }
            
            return dealerHand.GetStatus();
        }
    }
}
