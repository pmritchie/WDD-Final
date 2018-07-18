using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrickRitchie_DVP2_Final
{
    class Program
    {
        static void Main(string[] args)
        {
            Player currentPlayer = new Player();
            Console.WriteLine("Let's play some Card Roulette!\n" +
                "1: New User\n" +
                "2: Existing User\n"+
                "3: Exit\n");

            int userChoice = Validation.GetInt(1, 3, "Select from the options above: ");
            switch (userChoice)
            {
                case 1:
                    {
                        string newPlayer = Validation.WhiteNull("Enter Player Name: ");
                        currentPlayer.Name = newPlayer;

                        int credits = 500;
                        Credits addCredits = new Credits(credits);
                        currentPlayer.SetCredits(addCredits);

                        Console.WriteLine($"Welcome, {currentPlayer.Name}! You are starting with {currentPlayer.GetCredits().GetCredits()} credits!\n" +
                            "Let's Play!");
                    }
                    break;
                case 2:
                    {
                        
                    }
                    break;
                case 3:
                    {
                        
                    }
                    break;

            }

         



        }
    }
}
