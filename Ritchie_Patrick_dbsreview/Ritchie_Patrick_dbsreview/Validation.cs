using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ritchie_Patrick_dbsreview
{
    class Validation
    {
        public static string WhiteNull(string message = "Please do not leave blank: ")
        {

            string input = null;
            do
            {
                Console.Write(message);
                input = Console.ReadLine();

            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }
    }
}
