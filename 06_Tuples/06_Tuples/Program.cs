public class SimpleTuple<T1, T2>
{
    public T1 Item1 { get; }

    public T2 Item2 { get; }
    public SimpleTuple(T1 item1, T2 item2)
    {
        Item1 = item1;
        Item2 = item2;
    }
}