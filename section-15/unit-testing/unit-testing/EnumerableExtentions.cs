public static class EnumerableExtentions
{
    public static int SumOfEvenNumbers(this IEnumerable<int> numbers)
    {
        int sum = 0;

        foreach (int number in numbers)
        {
            if (number % 2 == 0)
            {
                sum += number;
            }
        }
        return sum;

    }
}