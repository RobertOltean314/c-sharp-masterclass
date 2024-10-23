using _03_Dice_Roller.Game;

var random = new Random();
var dice = new Dice(random);
var guessingGame = new GuessingGame(dice);

var gameResult = guessingGame.Play();
GuessingGame.PrintResult(gameResult);

Console.ReadKey();
