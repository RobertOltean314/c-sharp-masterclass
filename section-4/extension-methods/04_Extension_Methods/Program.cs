using System;

namespace Coding.Exercise
{
    public static class ListExtensions
    {
        public static List<int> TakeEverySecond(this List<int> originalList)
        {
            List<int> modifiedList = new();

            for (int i = 0; i < originalList.Count; i += 2)
            {
                modifiedList.Add(originalList[i]);
            }
            return modifiedList;
        }
    }
}
