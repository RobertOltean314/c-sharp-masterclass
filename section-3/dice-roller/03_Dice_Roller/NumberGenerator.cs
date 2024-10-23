class NumberGenerator
{
    Random diceRolled = new Random();

    public int generateRandomNumber()
    {
        return diceRolled.Next(7);
    }
}

