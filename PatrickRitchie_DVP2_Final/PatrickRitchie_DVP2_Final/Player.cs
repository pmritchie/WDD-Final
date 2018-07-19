using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrickRitchie_DVP2_Final
{
    class Player
    {
        private string _userName;
        private int _credits;
        

        public Player()
        {

        }
        public Player(string userName, int credits)
        {
            _userName = userName;
            _credits = credits;
            
        }

        public string Name
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public int Credits
        {
            get { return _credits; }
            set { _credits = value; }
        }


    }
}
