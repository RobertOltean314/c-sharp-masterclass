class DiceRollApp
{
    private int chancesLeft;
    public int userGuess;
    private NumberGenerator numberGenerator;

    public DiceRollApp()
    {
        chancesLeft = 3;
        numberGenerator = new NumberGenerator();
        showInstructions();
    }

    private void showInstructions()
    {
        Console.WriteLine("Dice rolled.");
        Console.WriteLine($"Guess what number it shows in {chancesLeft} tries.");
    }

    private int GetUserGuess()
    {
        Console.WriteLine("Enter a number: ");
        while (true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out int guess))
            {
                return guess;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
    }

    public void Run()
    {
        int numberToBeGuessed = numberGenerator.generateRandomNumber();

        while (chancesLeft > 0)
        {
            userGuess = GetUserGuess();

            if (userGuess != numberToBeGuessed)
            {
                chancesLeft--;
                Console.WriteLine("Wrong number. Try again.");
                if (chancesLeft > 0)
                {
                    Console.WriteLine($"You have {chancesLeft} chances left.");
                }
            }
            else
            {
                Console.WriteLine("You win!");
                break;
            }
        }

        if (chancesLeft == 0)
        {
            Console.WriteLine("Game over. You've used all your chances.");
        }

        Console.ReadKey();
    }
}
