using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;

namespace PatrickRitchie_DVP2_Final
{
    class Validation
    {
        public static string WhiteNull(string message = "Please do not leave blank: ")
        {

            string input = null;
            do
            {
                Console.WriteLine(message, Color.Goldenrod);
                input = Console.ReadLine();

            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        public static int GetInt(int min, int max, string message = "Input an interger only for options")
        {
            int returnValue = 0;
            string input;
            do
            {
                Console.WriteLine(message, Color.Goldenrod);
                input = Console.ReadLine();

            } while (!(Int32.TryParse(input, out returnValue) && returnValue >= min && returnValue <= max));

            return returnValue;
        }
    }
}
