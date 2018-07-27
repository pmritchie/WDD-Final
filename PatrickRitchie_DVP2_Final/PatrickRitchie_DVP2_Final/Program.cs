using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Drawing;
using Console = Colorful.Console;
namespace PatrickRitchie_DVP2_Final
{
    class Program
    {
        
        static string outputFolder = @"..\..\Output\";
        static string fileName = @"Player.json";
        static void Main(string[] args)
        {
      
            Directory.CreateDirectory(outputFolder);
            bool programIsRunning = true;
            Player currentPlayer = new Player();
            MainMenu();
           
            //save data
            void SavePlayerJSON(Player name) {

                //checks to see if file exists, if it does, load into a list to be rewritten as a new file with new info
                if (File.Exists(outputFolder+fileName)) {
                    Console.Clear();


                    List<Player> converted;
                    using (StreamReader sr = new StreamReader(outputFolder+fileName))
                    { 
                        string json = sr.ReadToEnd();
                        List<Player> convert = JsonConvert.DeserializeObject<List<Player>>(json);
                        converted = convert;
                        sr.Close();
                    }

                    if (converted.Contains(name))
                    {
                        Console.WriteLine("That name has been choosen, please choose a different name");
                        MainMenu();
                    }
                    else
                    {

                        using (StreamWriter sw = new StreamWriter(outputFolder+fileName))
                        {
                            sw.WriteLine("[");
                            //add the existing players
                            foreach (var item in converted)
                            {
                                
                                sw.WriteLine("{");
                                sw.Write($"\"Name\" : \"{item.Name}\",");
                                sw.Write($"\"Credits\" : \"{item.Credits}\",");
                                sw.WriteLine("},");

                            }
                            //writes in new player

                            sw.WriteLine("{");
                            sw.Write($"\"Name\" : \"{name.Name}\",");
                            sw.Write($"\"Credits\" : \"{name.Credits}\"");
                            sw.WriteLine("}");
                            sw.WriteLine("]");

                            sw.Close();

                        }
                    }

                    
                } else
                {
                    using (StreamWriter sw = new StreamWriter(outputFolder+fileName))
                    {
                        sw.WriteLine("[");
                        sw.WriteLine("{");
                        sw.Write($"\"Name\" : \"{name.Name}\",");
                        sw.Write($"\"Credits\" : \"{name.Credits}\"");
                        sw.WriteLine("}");
                        sw.WriteLine("]");

                        sw.Close();
                    }
                }
            }
            // function to load and choose players
             void LoadJsonPlayers()
            {
                if (File.Exists(outputFolder+fileName))
                {
                    using (StreamReader sr = new StreamReader(outputFolder+fileName))
                    {
                        string json = sr.ReadToEnd();
                        List<Player> convert = JsonConvert.DeserializeObject<List<Player>>(json);
                        int assignment = 1;
                        int r = 255;
                        int g = 200;
                        int b = 150;
                        foreach (var item in convert)
                        {
                            Console.WriteLine($"{assignment}\nName: {item.Name}\nCredits: {item.Credits}",Color.FromArgb(r,g,b));
                            assignment++;
                            r -= 50;
                            b -= 50;
                        }
                        int userChoice = Validation.GetInt(1, convert.Count, "Select from the options above: ");
                        currentPlayer = convert[userChoice-1];
                        Console.Clear();
                        Console.WriteLine($"Welcome {currentPlayer.Name}! Lets play some cards! Your current credits are at {currentPlayer.Credits}!\n",Color.Goldenrod);
                        sr.Close();
                    }
                }
                else
                {
                    Console.WriteLine("There are no profiles available, create one first", Color.Pink);
                }
            }
            // start game loop
            void PlayGame()
            {
                bool runGame = true;
                while (runGame)
                {
                    // make deck of cards, suffle and deal cards
                    
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
                        

                        Console.WriteLine($"You have drawn {playerPick.face} of {playerPick.suit}!\n" +
                            "How much would you like to bet?", Color.LightBlue);
                        int playerBet = Validation.GetInt(0, currentPlayer.Credits,$"Place a bet between $0 and ${currentPlayer.Credits}");
                        int computerMatch = playerBet;
                        int thePot = playerBet + computerMatch;
                        Console.WriteLine($"HAL has drawn {computerPick.face} of { computerPick.suit}!", Color.LightBlue);
                        

                        if((int)playerPick.face >(int)computerPick.face)
                        {
                            currentPlayer.Credits += computerMatch;
                            Console.WriteLine(" You won! You beat HAL this round!\n"+
                                $"You have won {thePot} credits this round\n\n"+
                                $"Total Credits: {currentPlayer.Credits}", Color.Goldenrod);
                            Utility.PauseBeforeContinuing();
                        }
                        else if((int) playerPick.face < (int)computerPick.face)
                        {
                            
                            currentPlayer.Credits -= playerBet;
                            Console.WriteLine("HAL won! Don't let HAL win anymore!" +
                                $"You lost {thePot} credits this round.\n\n" +
                                $"Total Credits: {currentPlayer.Credits}", Color.Goldenrod);
                            Utility.PauseBeforeContinuing();
                        }
                        else// incase of a draw, double or nothing
                        {
                            Console.WriteLine("Oh look a draw!! Double or nothing now!",Color.HotPink);
                            while((int) playerPick.face == (int)computerPick.face)
                            {
                                playerPick = (PlayingCard)player.draw();
                                computerPick = (PlayingCard)computer.draw();

                                
                                Console.WriteLine($"You have drawn {playerPick.face} of {playerPick.suit}!\n"+
                                    $"Hal has drawn a {computerPick.face} of {computerPick.suit}\n\n",Color.LightBlue);

                                if ((int)playerPick.face > (int)computerPick.face)
                                {
                                    currentPlayer.Credits += thePot;
                                    Console.WriteLine(" You won! You beat HAL this round!\n" +
                                        $"You have won {thePot} credits this round\n\n" +
                                        $"Total Credits: {currentPlayer.Credits}", Color.Goldenrod);
                                    Utility.PauseBeforeContinuing();

                                }
                                else if ((int)playerPick.face < (int)computerPick.face)
                                {
                                    currentPlayer.Credits -= thePot;
                                    Console.WriteLine("HAL won! Don't let HAL win anymore!" +
                                         $"You lost {playerBet *2} credits this round.\n\n" +
                                         $"Total Credits: {currentPlayer.Credits}", Color.Goldenrod);
                                    Utility.PauseBeforeContinuing();
                                }
                            }
                            

                        }
                        if (currentPlayer.Credits <= 0)
                        {
                            Console.WriteLine("You Lose! Better Luck Next time!", Color.LightBlue);
                            currentPlayer = null;
                            Utility.PauseBeforeContinuing();
                            MainMenu();
                        }
                        else
                        {
                            //to continue, main menu or quit
                            Console.WriteLine("Continue?\n\n" +
                                "1: Yes\n" +
                                "2: Main Menu\n" +
                                "3: Save and Quit\n", Color.Goldenrod);

                            int choice = Validation.GetInt(1, 3, "Choose an option above\n");
                            Console.Clear();
                            switch (choice)
                            {
                                case 1:
                                    {
                                        Console.WriteLine("Alright, let's keep going!", Color.LightBlue);
                                    }
                                    break;
                                case 2:
                                    {
                                        SavePlayerJSON(currentPlayer);
                                        runGame = false;
                                        MainMenu();
                                    }
                                    break;
                                case 3:
                                    {
                                        SavePlayerJSON(currentPlayer);
                                        runGame = false;
                                        Environment.Exit(0);
                                    }
                                    break;
                            }
                        }

                    }
                }

                
            }
            //main menu
            void MainMenu()
            {
          
                //loop through main menu
                while (programIsRunning)
                {
                    int d = 244;
                    int v = 212;
                    int i = 255;
                    for(int j = 0; j < 3; j++)
                    {
                        Console.WriteAscii("   CARD ROULETTE", Color.FromArgb(d, v, i));
                        d -= 18;
                        v -= 36;
                    }
                    Console.WriteLine ("                         Let's play some Card Roulette with HAL from 2001: A Space Odyssey!\n" +
                        "                                             1: New User\n" +
                        "                                             2: Existing User\n" +
                        "                                             3: Exit\n", Color.Goldenrod);
                    //user selection
                    int userChoice = Validation.GetInt(1, 3, "                                     Select from the options above: ");
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
                                Console.WriteAscii("CARD ROULETTE", Color.FromArgb(d, v, i));
                                Console.WriteLine($"Welcome, {currentPlayer.Name}! You are starting with {currentPlayer.Credits} credits!\n" +
                                    "Let's Play!",Color.Goldenrod);

                                
                                PlayGame();
                                
                                Console.Clear();
                            }
                            break;
                        case 2:
                            {
                                //load player data and choose player

                                LoadJsonPlayers();
                                if(currentPlayer != null)
                                {
                                    
                                    PlayGame();
                                }


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
