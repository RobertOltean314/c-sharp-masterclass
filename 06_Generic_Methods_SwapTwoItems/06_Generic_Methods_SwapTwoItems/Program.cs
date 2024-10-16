using System;

namespace Coding.Exercise
{
    public static class TupleSwapExercise
    {
        //your code goes here

        public static Tuple<TFirst, TSecond> SwapTupleItems<TFirst, TSecond>(
            Tuple<TFirst, TSecond> tuple)
        {
            new Tuple<TSecond, TFirst>(tuple.Item2, tuple.Item1);
        }
    }
}
