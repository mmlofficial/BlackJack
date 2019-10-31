using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackTest
{
    class Card
    {
        private string Suit;
        private string Value;
        private int Cost;

        public Card(string value, string suit)
        {
            this.Suit = suit;
            this.Value = value;
            this.Cost = CardVariables.GetDcost(value);
        }

        public string getValue ()
        {
            return this.Value;
        }

        public int getCost()
        {
            return this.Cost;
        }

        public string GetCard()
        {
            return this.Value + this.Suit;
        }
    }
}
