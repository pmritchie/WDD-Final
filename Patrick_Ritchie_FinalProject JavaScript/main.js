	var currentPlayer = new Player();

	function inputInt(message){
	var input = "";	
	while(input == "" || Number.isInteger(input) == false){
		var input = window.prompt(message)
		if (!Number.isInteger(parseInt(input))){
	alert("Please enter an number to continue.")
		}
	else{
		input = parseInt(input)
		return input;
		}
	}
}
	function inputBlank(message){
		var input = "";
		while(input == "" || input.valueOf() == 0){
			var input = window.prompt(message)
			if(!input.valueOf()== 0){
				alert("Please enter a name to continue.")
			}else{
				
				return input;
			}
		}
	}
function MainMenu(){
var userChoice = inputInt("Let's play some Card Roulette with HAL from 2001: A Space Odyssey!\n" +
                        "1: New User\n" +
                        "2: Existing User\n" +
                        "3: Exit\n")
switch (userChoice){
	case 1: var newPlayer =inputBlank("Enter Player Name: ");
	currentPlayer.userName = newPlayer
	currentPlayer.credits = 500
	alert("Welcome "+currentPlayer.userName+"! You are starting with "+currentPlayer.credits+" credits!\n Let's Play!");

	 break;
	case 2:  break;
	case 3:  break;
}
}
function PlayGame(){

	var bool = true;
	while (bool){

		var mainDeck = PlayingDeck();
		mainDeck.newDeck();
		mainDeck.shuffle();

		var player = PlayingDeck();
		var computer = PlayingDeck();

		var boo = false;
		mainDeck.forEach(function(item){
			if(boo){
				player.stack.push(item)
			}else{
				computer.stack.push(item)
			}
		}

		while(!player.isEmpty() && !computer.isEmpty()){
			var playerPick =(PlayingCard)player.draw();
			var computerPick =(PlayingCard)computer.draw();

			alert("You have drawn"+playerPick.face+ " of "+playerPick.suit+"!\n");
                           var playerBet = inputInt("How much would you like to bet?");
                           var computerBet = playerBet;
                           var thePot = playerBet + computerBet;
                           alert("HAL has drawn "+computerPick.face+" of "+computerPick.suit+"!")

                           if(playerPick.face.valueOf() > computerPick.face.valueOf()){
                           	       currentPlayer.Credits += thePot;
                            alert(" You won! You beat HAL this round!\n"+
                                $"You have won "+thePot+" credits this round\n\n"+
                                $"Total Credits: "+currentPlayer.Credits+"");

                           }else if(playerPick.face.valueOf() < computerPick.face.valueOf())
                           {
                           	currentPlayer.Credits -= thePot;
                            alert("HAL won! Don't let HAL win anymore!" +
                                "You lost "+thePot+" credits this round.\n\n" +
                                "Total Credits: "+currentPlayer.Credits+"");

                           }else{
                           	alert("Oh look a draw!! Double or nothing now!");
                            while(playerPick.face.valueOf() == computerPick.face.valueOf())
                            {
                                playerPick = (PlayingCard)player.draw();
                                computerPick = (PlayingCard)computer.draw();
                                
                                thePot = thePot * 2;
                                alert("You have drawn "+playerPick.face+" of "+playerPick.suit+"!\n"+
                                    "Hal has drawn a "+computerPick.face+" of "+computerPick.suit+"\n\n");

                                if ((int)playerPick.face > (int)computerPick.face)
                                {
                                    currentPlayer.Credits += thePot;
                                    Console.WriteLine(" You won! You beat HAL this round!\n" +
                                        $"You have won "+thePot+" credits this round\n\n" +
                                        $"Total Credits: "+currentPlayer.Credits+"");
                                    Utility.PauseBeforeContinuing();

                                }
                                else if ((int)playerPick.face < (int)computerPick.face)
                                {
                                    currentPlayer.Credits -= playerBet *2;
                                    Console.WriteLine("HAL won! Don't let HAL win anymore!" +
                                         $"You lost "+playerBet * 2+" credits this round.\n\n" +
                                         $"Total Credits: "+currentPlayer.Credits+"");
                                    Utility.PauseBeforeContinuing();
                                }
                            }
                           }
                        if (currentPlayer.Credits <= 0)
                        {
                            alert("You Lose! Better Luck Next time!");
                            currentPlayer = null;
                            
                            MainMenu();
                        }
                        else
                        {
                            //to continue, main menu or quit
                            Console.WriteLine("Continue?\n\n" +
                                "1: Yes\n" +
                                "2: Main Menu\n" +
                                "3: Save and Quit\n");

                            int choice = Validation.GetInt(1, 3, "Choose an option above\n");
                            switch (choice)
                            {
                                case 1:
                                    {
                                        Console.WriteLine("Alright, let's keep going!");
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

	class Card{
		var suit = ["Heats":0, "Clubs":1, "Diamonds":2, "Spades":3]
		var face = ["Two":1, "Three":2,"Four":3,"Five":4,"Six":5,"Seven":6,"Eight":7,"Nine":8,"Ten":9, "Jack":10, "Queen":11, "King":12,"Ace":13]
		constructor(suit , face ){
				this.suit = suit;
				this.face = face;
		}

	
	}

	class PlayingCard extends Card{
		constructor(suit, face)
		super(suit, face)

		function GetValue(){
			return ((var)suit);
		}
	}

	class Deck{
		public var stack = Card[];

		function Deck(){
			this.stack = new Card[];
		}

	}
	class PlayingDeck extends Deck
	{
		function newDeck(){
			for (var i = 0; i <4; i++) {
				for (var j = 1; j< 14; j++) {			
				  stack.add(new PlayingCard((Card.suit)i, (Card.face)j));
				}
		}

		function shuffle(){
			var random = Math.random();

			for (var i = stack.length - 1; i > 1; i--) {
		    var nxt = random.next(i)
		    temp = (PlayingCard)stack[nxt];
		    stack[nxt] = stack[i];
		    stack[i] = temp;
		}

	 function draw(){
	 	var card = (PlayingCard)stack[0];
	 	stack.remove(card);

	 	return (card);
	 }
	 function putInDeck(Card p1, Card p2){
	 	stack.push(p1);
	 	stack.push(p2);
	 	shuffle();
	 }
	 function isEmpty(){
	 	return(stack.length <= 0);
	 }
	}
	class Player{
		constructor(userName, credits){
		this.userName = userName;
		this.credits = credits;
	}

	}
	