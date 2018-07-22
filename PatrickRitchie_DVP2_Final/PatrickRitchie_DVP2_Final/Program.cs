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
            MainMenu();
           
           




            void SavePlayerJSON(Player name) {

                //checks to see if file exists, if it does, load into a list to be rewritten as a new file with new info
                if (File.Exists("Player.json")) {

                    List<Player> converted;
                    using (StreamReader sr = new StreamReader("Player.json"))
                    { 
                        string json = sr.ReadToEnd();
                        List<Player> convert = JsonConvert.DeserializeObject<List<Player>>(json);
                        converted = convert;
                    }
                    
                    
                        using (StreamWriter sw = new StreamWriter("Player.json"))
                        {
                        //add the existing players
                        foreach (var item in converted)
                        {
                            sw.WriteLine("[");
                            sw.WriteLine("{");
                            sw.WriteLine($"\"Name\" : \"{item.Name}\",");
                            sw.WriteLine($"\"Credits\" : \"{item.Credits}\",");
                            sw.WriteLine("},");
                           
                        }
                        //writes in new player
                          
                            sw.WriteLine("{");
                            sw.WriteLine($"\"Name\" : \"{name.Name}\",");
                            sw.WriteLine($"\"Credits\" : \"{name.Credits}\",");
                            sw.WriteLine("}");
                            sw.WriteLine("]");

                        }

                    
                } else
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
            }


            // function to load and choose players
             void LoadJsonPlayers()
            {
                if (File.Exists("Player.json"))
                {
                    using (StreamReader sr = new StreamReader("Player.json"))
                    {
                        string json = sr.ReadToEnd();
                        List<Player> convert = JsonConvert.DeserializeObject<List<Player>>(json);
                        int assignment = 1;
                        foreach (var item in convert)
                        {
                            Console.WriteLine("{0}\nName: {1}\nCredits: {2}", assignment, item.Name, item.Credits);
                            assignment++;
                        }
                        int userChoice = Validation.GetInt(1, convert.Count, "Select from the options above: ");
                        currentPlayer = convert[userChoice - 1];
                        Console.WriteLine("Welcome {0}! Lets play some cards! Your current credits are at {1}!", currentPlayer.Name, currentPlayer.Credits);
                    }
                }
                else
                {
                    Console.WriteLine("There are no profiles available, create one first");
                }
            }

            void PlayGame()
            {
                bool runGame = true;
                while (runGame)
                {
                    // make deck of cards, suffle and deal cards
                    int moves = 0;
                    PlayingDeck mainDeck = new PlayingDeck();
                    mainDeck.newDeck();
                    mainDeck.shuffle();

                    PlayingDeck player = new PlayingDeck();
                    PlayingDeck computer = new PlayingDeck();

                    bool boo = false;

                    foreach (PlayingCard card in mainDeck.stack){
                        if (boo)
                        {
                            player.stack.Add(card);
                        }
                        else
                        {
                            computer.stack.Add(card);
                        }
                        boo = !boo;
                    }
                    // loop to keep playing game
                    while(!player.isEmpty() && !computer.isEmpty())
                    {
                        
                        PlayingCard playerPick = (PlayingCard)player.draw();
                        PlayingCard computerPick = (PlayingCard)computer.draw();
                        moves++;

                        Console.WriteLine($"You have drawn {playerPick.face} of {playerPick.suit}!\n" +
                            "How much would you like to bet?");
                        int playerBet = Validation.GetInt(0, currentPlayer.Credits,$"Place a bet between $0 and ${currentPlayer.Credits}");
                        int computerMatch = playerBet;
                        int thePot = playerBet + computerMatch;
                        Console.WriteLine($"HAL has drawn {computerPick.face} of { computerPick.suit}!");
                        

                        if((int)playerPick.face >(int)computerPick.face)
                        {
                            currentPlayer.Credits += thePot;
                            Console.WriteLine(" You won! You beat HAL this round!\n"+
                                $"You have won {thePot} credits this round\n\n"+
                                $"Total Credits: {currentPlayer.Credits}");
                        }
                        else if((int) playerPick.face < (int)computerPick.face)
                        {
                            
                            currentPlayer.Credits -= thePot;
                            Console.WriteLine("HAL won! Don't let HAL win anymore!" +
                                $"You lost {thePot} credits this round.\n\n" +
                                $"Total Credits: {currentPlayer.Credits}");
                        }
                        else// incase of a draw, double or nothing
                        {
                            Console.WriteLine("Oh look a draw!! Double or nothing now!");
                            while((int) playerPick.face == (int)computerPick.face)
                            {
                                playerPick = (PlayingCard)player.draw();
                                computerPick = (PlayingCard)computer.draw();
                                moves++;
                                thePot = thePot * 2;
                                Console.WriteLine($"You have drawn {playerPick.face} of {playerPick.suit}!\n"+
                                    $"Hal has drawn a {computerPick.face} of {computerPick.suit}\n\n");

                                if ((int)playerPick.face > (int)computerPick.face)
                                {
                                    currentPlayer.Credits += thePot;
                                    Console.WriteLine(" You won! You beat HAL this round!\n" +
                                        $"You have won {thePot} credits this round\n\n" +
                                        $"Total Credits: {currentPlayer.Credits}");

                                }
                                else if ((int)playerPick.face < (int)computerPick.face)
                                {
                                    currentPlayer.Credits -= thePot;
                                    Console.WriteLine("HAL won! Don't let HAL win anymore!" +
                                         $"You lost {playerBet *2} credits this round.\n\n" +
                                         $"Total Credits: {currentPlayer.Credits}");
                                }
                            }
                            

                        }
                        //to continue, main menu or quit
                        Console.WriteLine("Continue?\n\n"+
                            "1: Yes\n"+
                            "2: Main Menu\n"+
                            "3: Save and Quit\n");

                        int choice = Validation.GetInt(1, 3, "Choose an option above\n");
                        switch (choice)
                        {
                            case 1:
                                {
                                    Console.WriteLine("Alright, let's keep going!");
                                }break;
                            case 2:
                                {
                                    SavePlayerJSON(currentPlayer);
                                    runGame = false;
                                    MainMenu();
                                }break;
                            case 3:
                                {
                                    SavePlayerJSON(currentPlayer);
                                    runGame = false;
                                    //add quit app
                                }break;
                        }

                    }
                }

                
            }

            void MainMenu()
            {
          
                //loop through main menu
                while (programIsRunning)
                {
                    Console.WriteLine("Let's play some Card Roulette with HAL from 2001: A Space Odyssey!\n" +
                        "1: New User\n" +
                        "2: Existing User\n" +
                        "3: Exit\n");
                    //user selection
                    int userChoice = Validation.GetInt(1, 3, "Select from the options above: ");
                    Console.Clear();
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


                                PlayGame();
                                SavePlayerJSON(currentPlayer);
                                Console.Clear();
                            }
                            break;
                        case 2:
                            {
                                //load player data and choose player

                                LoadJsonPlayers();
                                PlayGame();

                                Console.Clear();

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
            }
            
        }
    }
}
