namespace _03_Dice_Roller.Game;

public class Dice
{
    private readonly Random _random;
    private const int slices = 6;

    public Dice(Random random)
    {
        _random = random;
    }

    public int Roll() => _random.Next(1, slices + 1);

}
