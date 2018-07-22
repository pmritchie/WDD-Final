using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrickRitchie_DVP2_Final
{
    class PlayingCard : Card
    {
        public PlayingCard (Suit s, Face f) : base (s, f)
        {

        }

        public override int getValue()
        {
            return ((int)suit);
        }



    }

    public class PlayingDeck: Deck
    {
        public override void newDeck()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 14; j++)
                {
                    stack.Add(new PlayingCard((Card.Suit) i, (Card.Face)j));
                }
            }
        }

        public override void shuffle()
        {
            Random rdm = new Random();

            for (int i = stack.Count -1; i > 1; i--)
            {
                int nxt = rdm.Next(i);

                PlayingCard temp = (PlayingCard)stack[nxt];
                stack[nxt] = stack[i];
                stack[i] = temp;

            }
        }

        public override Card draw()
        {
            PlayingCard card = (PlayingCard)stack[0];
            stack.Remove(card);

            return (card);
        }

        public override void putInDeck(Card p1, Card p2)
        {
            stack.Add(p1);
            stack.Add(p2);
            shuffle();
        }

        public override bool isEmpty()
        {
            return (stack.Count <= 0);
        }
    }

}
