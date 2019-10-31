using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackTest
{
    class Deck
    {
        private List<Card> Gdeck;

        public Deck(int n)
        {
            this.Gdeck = new List<Card>();
            int k;
            if (n == 36)
                k = 4;
            else
                k = 0;

            int len = CardVariables.Value.Length;
            for (int i = k; i < len; i++)
            {
                Gdeck.Add(new Card(CardVariables.Value[i], CardVariables.Spades()));
                Gdeck.Add(new Card(CardVariables.Value[i], CardVariables.Hearts()));
                Gdeck.Add(new Card(CardVariables.Value[i], CardVariables.Diamonds()));
                Gdeck.Add(new Card(CardVariables.Value[i], CardVariables.Clubs()));
            }
            this.Shuffle();
        }

        private void Shuffle()
        {
            Random rand = new Random();
            for (int i = this.Gdeck.Count - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                Card tmp = Gdeck[j];
                this.Gdeck[j] = this.Gdeck[i];
                this.Gdeck[i] = tmp;
            }
        }

        public Card this[int i]
        {
            get { return Gdeck[i]; }
            //set { gdeck[i] = value;}
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < Gdeck.Count; i++)
            {
                if (i % 6 == 0)
                    str += '\n';
                str += Gdeck[i].GetCard() + " ";
            }
            return str;
        }

        
        public List<Card> GetGdeck()
        {
            return this.Gdeck;
        }

    }
}
