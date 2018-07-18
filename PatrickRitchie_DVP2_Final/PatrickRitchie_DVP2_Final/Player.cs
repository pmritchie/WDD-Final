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
        Credits _playerCredits;

        public Player()
        {

        }
        public Player(string userName)
        {
            _userName = userName;
            
        }

        public string Name
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public Credits GetCredits()
        {
            return _playerCredits;
        }

        public void SetCredits(Credits credits)
        {
            _playerCredits = credits;
        }
    }
}
