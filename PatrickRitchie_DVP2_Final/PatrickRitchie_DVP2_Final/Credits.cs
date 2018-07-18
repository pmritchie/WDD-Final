using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrickRitchie_DVP2_Final
{
    class Credits
    {
        private int _credits;

        public Credits()
        {

        }

        public Credits(int credits)
        {
            _credits = credits;

        }

        public int GetCredits()
        {
            return _credits;
        }
        public void SetCredits(int credits)
        {
            _credits = credits;
        }
    }
}
