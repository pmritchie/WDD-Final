using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace PatrickRitchie_DVP2_Final
{
    class Program
    {
        static void Main(string[] args)
        {
            bool programIsRunning = true;
            Player currentPlayer = new Player();
            //loop through main menu
            while (programIsRunning)
            {
                Console.WriteLine("Let's play some Card Roulette!\n" +
                    "1: New User\n" +
                    "2: Existing User\n" +
                    "3: Exit\n");
                //user selection
                int userChoice = Validation.GetInt(1, 3, "Select from the options above: ");
                switch (userChoice)
                {
                    case 1:
                        {
                            //creates player and saves player data in JSON
                            string newPlayer = Validation.WhiteNull("Enter Player Name: ");
                            currentPlayer.Name = newPlayer;

                            int credits = 500;
                            currentPlayer.Credits = credits;

                            Console.WriteLine($"Welcome, {currentPlayer.Name}! You are starting with {currentPlayer.Credits} credits!\n" +
                                "Let's Play!");
                            SavePlayerJSON(currentPlayer);
                        }
                        break;
                    case 2:
                        {
                            //load player data and choose player

                            LoadJsonPlayers();


                        }
                        break;
                    case 3:
                        {
                            programIsRunning = false;
                            Utility.PauseBeforeContinuing();
                        }
                        break;

                }
            }




             void SavePlayerJSON(Player name)
            {
                using (StreamWriter sw = new StreamWriter("Player.json"))
                {
                    sw.WriteLine("[");
                        sw.WriteLine("{");
                        sw.WriteLine($"\"Name\" : \"{name.Name}\",");
                        sw.WriteLine($"\"Credits\" : \"{name.Credits}\",");
                        sw.WriteLine("}");
                    sw.WriteLine("]");

                }
            }


            
             void LoadJsonPlayers()
            {
                using (StreamReader sr = new StreamReader("Player.json"))
                {
                    string json = sr.ReadToEnd();
                    List<Player> convert = JsonConvert.DeserializeObject<List<Player>>(json);
                    int assignment = 1;
                    foreach (var item in convert)
                    {
                        Console.WriteLine("{0}\nName: {1}\nCredits: {2}",assignment, item.Name, item.Credits);
                        assignment ++;
                    }
                    int userChoice = Validation.GetInt(1, convert.Capacity, "Select from the options above: ");
                    currentPlayer = convert[userChoice-1];
                    Console.WriteLine("Welcome {0}! Lets play some cards! Your current credits are at {1}!", currentPlayer.Name, currentPlayer.Credits);
                }
            }
            
        }
    }
}
