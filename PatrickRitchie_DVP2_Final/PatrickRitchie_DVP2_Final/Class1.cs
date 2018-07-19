using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrickRitchie_DVP2_Final
{
    class Suits : Cards
    {
        string suit;
        public Suits()
        {

        }
        public Suits(string _suit)
        {
            suit = _suit;
        }
        public string Suit
        {
            get { return suit; }
            set { suit = value; }
        }
    }
}
