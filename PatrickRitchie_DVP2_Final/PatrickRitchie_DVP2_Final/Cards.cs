using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrickRitchie_DVP2_Final
{
    class Cards
    {
        private string face;
        private int value;

        public Cards()
        {

        }
        public Cards(string _face, int _value)
        {
            face = _face;
            this.value = _value;
        }
        public override string ToString()
        {
            return face + " is worth" + value;
        }

    }
}
