
class Player
{
		
		constructor(userName, credits){
		this.userName = userName;
		this.credits = credits;
		}

	}
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


// function shuffle() {

// 	var random = Math.floor((Math.random()*52)+1);
// 	for(var i = deck.length -1; i > 1; i--){
// 		var nxt = random
// 	}
// }
class Deck{
	constructor(){
		this.deck = [];
		this.dealCards = [];
	}
}

function createDeck(){
	var card = (suit, face) =>{
		this.name = face + ' of ' + suit;
		this.suit = suit;
		this.face = face;

		return{name:this.name, suit:this.suit, face:this.face}
	}

	var face = ['2','3','4','5','6','7','8','9','10','Jack','Queen','King','Ace']
	var suit = ['Hearts', 'Clubs','Spades','Diamonds']

	for (var s = 0; s < suit.length; s++){
		for(var f = 0; f < face.length; f++){
			this.deck.push(card(suit[s], face[f]))
		}
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
			

