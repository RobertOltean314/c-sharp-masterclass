using System;

namespace Coding.Exercise
{
    //your code goes here
    public class Pair<T>
    {
        public T First { get; private set; }
        public T Second { get; private set; }

        public Pair(T first, T second)
        {
            First = first;
            Second = second;
        }

        public void ResetFirst(T first)
        {
            First = default;
        }

        public void ResetSecond(T second)
        {
            Second = default;
        }
    }
}
