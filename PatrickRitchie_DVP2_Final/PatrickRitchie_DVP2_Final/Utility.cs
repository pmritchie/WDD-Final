using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;

namespace PatrickRitchie_DVP2_Final
{
    class Utility
    {
        public static void PauseBeforeContinuing()
        {
            Console.WriteLine("Press any key to continue.",Color.Aquamarine);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
