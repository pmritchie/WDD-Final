using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrickRitchie_DVP2_Final
{
    public abstract class Card
    {

        public enum Suit {Hearts =0, Clubs, Diamonds, Spades};
        public enum Face {two= 1, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jeck, Queen, King }
        public Suit suit;
        public Face face;

        public Card(Suit s, Face f)
        {
            this.suit = s;
            this.face = f;
        }

        public abstract int getValue();

    }
}
