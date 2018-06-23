using System;

namespace DSA.BLL.DataStructures.Sort
{
    public class BubbleSort<T> : ISort<T> where T : IComparable
    {
        public ICountable<T> Sort(ICountable<T> array)
        {
            var arr = (ICountable<T>) array.Clone();
            for (var i = 0; i < arr.Count - 1; i++)
            for (var j = 0; j < arr.Count - 1; j++)
                if (arr[j].CompareTo(arr[j + 1]) > 0)
                {
                    var tmp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = tmp;
                }

            return arr;
        }
    }
}