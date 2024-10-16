
public class DailyAccountState
{
    public int InitialState { get; }

    public int SumOfOperations { get; }

    public DailyAccountState(
        int initialState,
        int sumOfOperations)
    {
        InitialState = initialState;
        SumOfOperations = sumOfOperations;
    }

    //your code goes here

    public int EndOfDayState
    {
        get
        {
            int result = InitialState + SumOfOperations;
            return result;
        }
    }

    public string Report
    {
        get
        {
            DateTime today = DateTime.Now;
            return $"Day: {today.Day},month: {today.Month}, year: {today.Year}," +
                $" initial state: {InitialState}, end of day state: {EndOfDayState}";
        }
    }
}
