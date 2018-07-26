function inputInt(message){
		var input = "";	
			while(input == "" || Number.isInteger(input) == false){
					var input = window.prompt(message)
					if (!Number.isInteger(parseInt(input))){
						alert("Please enter an number to continue.")
						}else{
						input = parseInt(input)
		return input;
		}
	}
}
function inputBlank(message){
		var input = "";
		while(input == ""){
			var input = window.prompt(message)
			if(input.length == 0){
				alert("Please do not leave blank to continue.")
			}else{
				
				return input;
			}
		}
	}


 function playGame(){
	this.mainDeck = new Deck();
	this.mainDeck.createDeck(mainDeck);
	this.mainDeck.shuffle(mainDeck);

	this.playerDeck = new Deck
	this.computerDeck = new Deck();


	for(var i = 0; i <= 25; i++){
	
	this.playerDeck.deck[i] = this.mainDeck.deck.shift();
	this.computerDeck.deck[i]= this.mainDeck.deck.shift();
	
	 }
	 var runGame = true;
	 while(!playerDeck.deck.length == 0 && !computerDeck.deck.length == 0 && runGame){

	 		var playerPick = playerDeck.draw();
	 		var computerPick = computerDeck.draw();
	 		var playerBet = inputInt("You drew "+playerPick.name +"! How much would you like to bet?");
	 		var computerMatch = playerBet;
	 		var thePot = playerBet + computerMatch;

	 		if(playerPick.face.value > computerPick.face.value){
	 			currentPlayer.credits += computerMatch;
	 			alert("You won! HAL has drawn "+computerPick.name+"!\n"+
                                "You have won "+computerMatch+" credits this round\n\n"+
                                "Total Credits: "+currentPlayer.credits);
	 		}else if(playerPick.face.value < computerPick.face.value){
	 			currentPlayer.credits -= playerBet;
	 			alert("HAL won! HAL has drawn "+computerPick.name+"!\n" +
                                "You lost "+playerBet+" credits this round.\n\n" +
                                "Total Credits: "+currentPlayer.credits);
	 		}else{
	 			alert("Oh look a tie!! Double or nothing now!");
	 			while(playerPick.face.value == computerPick.face.value){
	 					playerPick = playerDeck.draw();
	 					computerPick = computerDeck.draw();

	 					
	 					alert("You have drawn "+playerPick.name+"\n" +
                                    "Hal has drawn a "+computerPick.name);
	 					if(playerPick.face.value > computerPick.face.value){
	 						currentPlayer.credits += thePot*2;
                                    alert(" You won! You beat HAL this round!\n" +
                                        "You have won "+thePot+" credits this round\n\n" +
                                        "Total Credits: "+currentPlayer.credits);
	 					}
	 					else if(playerPick.face.value < computerPick.face.value){
	 						currentPlayer.credits -= playerBet*2;
                                    alert(" You won! You beat HAL this round!\n" +
                                        "You have won "+thePot+" credits this round\n\n" +
                                        "Total Credits: "+currentPlayer.credits);

	 			}
	 		}	
	 }
}
}

class Player
{
		
		constructor(userName, credits){
		this.userName = userName;
		this.credits = credits;
		}

	}
class  Deck{
	constructor(){
		this.deck = [];
		
	}


 createDeck(){
		var card = (suit, face) =>{
		this.name = face.name + ' of ' + suit.name;
		this.suit = suit;
		this.face = face;

		return{name:this.name, suit:this.suit, face:this.face}
	}
	var face = [{value: 1, name: "2"},
				{value: 2, name: "3"},
				{value: 3, name: "4"},
				{value: 4, name: "5"},
				{value: 5, name: "6"},
				{value: 6, name: "7"},
				{value: 7, name: "8"},
				{value: 8, name: "9"},
				{value: 9, name: "10"},
				{value: 10, name: "Jack"},
				{value: 11, name: "Queen"},
				{value: 12, name: "King"},
				{value: 13, name: "Ace"}];

	//var face =  ['2':1,'3':2,'4':3,'5':4,'6':5,'7':6,'8':7,'9':8,'10':9,'Jack':10,'Queen':11,'King':12,'Ace':13}
	
	var suit = [{name: 'Hearts'}, {name:'Clubs'},{name:'Spades'},{name: 'Diamonds'}]

	for (var s = 0; s < suit.length; s++){
		for(var f = 0; f < face.length; f++){
			this.deck.push(card(suit[s], face[f]))
			}
		}

	}
shuffle() {
  		var index = this.deck.length, tmpFace, rdmIndex

  		while(0 != index){
  			rdmIndex = Math.floor(Math.random() * index)
  			index -= 1;
  			tmpFace = this.deck[index]
  			this.deck[index] = this.deck[rdmIndex]
  			this.deck[rdmIndex] = tmpFace
  		}
	}
draw(){
		var cardDealt = this.deck.shift()
		return cardDealt;
	}


}

var userChoice = inputInt("Let's play some Card Roulette with HAL from 2001: A Space Odyssey!\n" +
                         "1: New User\n" +
                         "2: Existing User\n" +
                         "3: Exit\n")
	switch (userChoice){
			case 1: var newPlayer =inputBlank("Enter Player Name: ");
				 	var currentPlayer = new Player(newPlayer,500);
				 	
				 	if(localStorage.getItem('players') == null){
				 		localStorage.setItem('players', JSON.stringify(currentPlayer));
				 	}else{
				 		var oldPlayers = [];
				 		oldPlayers.push(JSON.parse(localStorage.getItem('players')));

				 		oldPlayers.push(currentPlayer);
				 		localStorage.setItem('players', JSON.stringify(oldPlayers));
				 	}

					alert("Welcome "+currentPlayer.userName+"! You are starting with "+currentPlayer.credits+" credits!\n Let's Play!");
					var p = new Deck();
					playGame();
					 break;

			case 2:  
					var enterName = prompt('Enter Player Name');

					var savedData = [];
						savedData = JSON.parse(localStorage.getItem('players'))
						var containsPlayer = false;
						for(var i = 0; i < savedData.length; i++){
						
						if(savedData[i].userName == enterName){
							alert('Player found!')
					 		currentPlayer = new Player(savedData[i].userName, savedData[i].credits)
					 		containsPlayer = true;
					 		console.log(currentPlayer);
						}
					}
					if(containsPlayer != true){
						alert('Player not found.')
					}

					
					 break;
			case 3:  break;
				 }
			

