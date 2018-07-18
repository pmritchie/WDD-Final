using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ritchie_Patrick_CountCart
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Patrick Ritchie
             * 11-1-2017
             * Count Cart Assignment
             * 
             */

            string[] itemArray = new string[10] { "snack", "drink", "vegetable", "drink", "meat", "snack", "vegetable", "snack", "drink", "drink" };
            Console.WriteLine("Please choose from the items below to see how of each item much you have in your virtual cart.\r\n" +
                "Choose '1' for Snacks\r\n" +
                "Choose '2' for Drinks\r\n" +
                "Choose '3' for Vegetables\r\n" +
                "Choose '4' for Meat\r\n");
            string itemChoosenString = Console.ReadLine();
            int itemChoosen;

            while (string.IsNullOrWhiteSpace(itemChoosenString))
            {
                Console.WriteLine("Please only choose from the options listed above and press RETURN.");
                itemChoosenString = Console.ReadLine();
            }
            while (!int.TryParse(itemChoosenString, out itemChoosen))
            {
                Console.WriteLine("Please ONLY choose from the options listed about and press RETURN.");
                itemChoosenString = Console.ReadLine();

            }
            while (itemChoosen <= 0 || itemChoosen >= 5)
            {
                Console.WriteLine("Please ONLY choose one of the options  '1' '2' '3' or '4' and press RETURN.");
                itemChoosenString = Console.ReadLine();
                
            }

            if (itemChoosen == 1)
            {
                itemChoosenString = ("snack");
            }
            else if (itemChoosen == 2)
            {
                itemChoosenString = ("drink");
            }
            else if (itemChoosen == 3)
            {
                itemChoosenString = ("vegetable");
            }
            else if (itemChoosen == 4)
            {
                itemChoosenString = ("meat");
            }

            int itemTotal = 0; //this is where it will store how many of each string there is

            


            for(int i = 0; i<itemArray.Length; i++)
            {
                
                
                if (itemArray[i].Contains(itemChoosenString))
                {
                    itemTotal++;
                }
            }
            Console.WriteLine("In your cart you have {0} {1}(s).", itemTotal, itemChoosenString);
            
            
            //tests

            //user input of 4
            // console output : In your cart you have 1 meat(s).
            //is correct
            //user input of 1
            //console output : In your cart you have 3 snack(s).
            //is correct.

        }
    }
}
