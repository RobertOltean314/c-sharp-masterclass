using _03_Dice_Roller.UserCommunication;

namespace _03_Dice_Roller.Game;
public class GuessingGame
{
    private readonly Dice _dice;
    private const int chances = 3;

    public GuessingGame(Dice dice)
    {
        _dice = dice;
    }

    public GameResult Play()
    {
        var diceRollResult = _dice.Roll();
        Console.WriteLine($"Dice rolled. Guess what the number in {chances}");

        var chancesLeft = chances;

        while (chancesLeft != 0)
        {
            var guess = ConsoleReader.ReadNumber("Enter a number: ");
            if (guess == diceRollResult)
            {
                return GameResult.Win;
            }
            else
            {
                --chancesLeft;
                Console.WriteLine("Try again!");
            }
        }
        return GameResult.Lose;
    }

    public static void PrintResult(GameResult gameResult)
    {
        string message = gameResult == GameResult.Win ? "You won!" : "You lost! :(";
        Console.WriteLine(message);
    }
}
