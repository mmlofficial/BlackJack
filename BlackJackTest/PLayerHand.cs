using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackTest
{
    class PlayerHand : Hand
    {
        public PlayerHand(Card card1, Card card2)
        {
            this.hand = new List<Card>();
            this.hand.Add(card1);
            this.hand.Add(card2);
            this.status = 0;
        }

        public override string ToString()
        {
            string str = "Your hand:\n";
            foreach (Card card in this.hand)
            {
                str += card.GetCard() + " ";
            }
            str += "(" + this.GetScore() + " points)\n";
            return str;
        }
    }
}
