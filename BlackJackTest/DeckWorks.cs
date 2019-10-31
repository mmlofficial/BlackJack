using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BlackJackTest
{
    class DeckWorks
    {
        private List<Card> AllCards;
        private int n, size;

        public DeckWorks(int n, int size)
        {
            this.AllCards = new List<Card>();
            this.n = n;
            this.size = size;
            //check n, size
            this.FillCards();
        }

        private void FillCards()
        {
            for (int i = 0; i < this.n; i++)
                this.AddDeck(this.size);
            this.Shuffle();
        }

        public void AddDeck(int n)
        { 
            this.AllCards.AddRange(new Deck(n).GetGdeck());

            this.Shuffle();
        }

        public void Shuffle()
        {
            Random rand = new Random();
            for (int i = this.AllCards.Count - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                Card tmp = AllCards[j];
                this.AllCards[j] = this.AllCards[i];
                this.AllCards[i] = tmp;
            }
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < AllCards.Count; i++)
            {
                if (i % 6 == 0)
                    str += '\n';
                str += AllCards[i].GetCard() + " ";
            }
            return str;
        }

        public Card PickCard()
        {
            
            if (AllCards.Count == 0)
            {
                Console.WriteLine("NEW deck!");
                this.FillCards();
            }
            Card card = AllCards.Last();
            this.AllCards.RemoveAt(AllCards.Count - 1);
            return card;
        }
    }
}