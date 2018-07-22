using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrickRitchie_DVP2_Final
{
    public abstract class Deck
    {
        public List<Card> stack;

        public Deck()
        {
            this.stack = new List<Card>();
        }

        public abstract void newDeck();
        public abstract void shuffle();
        public abstract Card draw();
        public abstract void putInDeck(Card p1, Card p2);
        public abstract bool isEmpty();
    }
}
