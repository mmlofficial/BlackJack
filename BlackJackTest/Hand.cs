using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackTest
{
    abstract class Hand
    {
        protected List<Card> hand;
        protected int status;

        public int GetSize()
        {
            return this.hand.Count;
        }

        public int GetScore() //need to test
        {
            int score = 0;
            int ace_count = 0;
            foreach (Card card in this.hand)
            {
                if (card.getValue() == "A")
                {
                    ace_count++;
                    continue;
                }
                score += card.getCost();
            }
            for (int i = 0; i < ace_count; i++)
            {
                if (score + ace_count <= 11)
                    score += 11;
                else
                    score++;
            }
            return score;
        }

        public void AddCard(Card card)
        {
            this.hand.Add(card);
        }

        // -1 - bust
        // 0 - ok
        // 1 - already has 21
        // 2 - blackjack

        public int GetStatus() //need to test
        {
            int score = this.GetScore();
            if (score > 21)
                this.status = -1;
            else if (score == 21)
            {
                this.status = 1;
                if (hand.Count == 2)
                    this.status = 2;
            }
            return this.status;
        }

        public Card this[int i]
        {
            get { return hand[i]; }
        }

        abstract public override string ToString();

    }
}
