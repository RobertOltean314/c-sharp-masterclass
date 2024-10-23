namespace _03_Dice_Roller.UserCommunication;
public static class ConsoleReader
{
    public static int ReadNumber(string message)
    {
        int result;
        do
        {
            Console.WriteLine(message);
        } while (!int.TryParse(Console.ReadLine(), out result));
        return result;
    }
}