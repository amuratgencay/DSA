using System;

namespace DSA.BLL.DataStructures.Sort
{
    public class ShellSort<T> : ISort<T> where T : IComparable
    {
        public ICountable<T> Sort(ICountable<T> array)
        {
            var arr = (ICountable<T>) array.Clone();
            var gap = arr.Count / 2;
            while (gap > 0)
            {
                for (var i = 0; i + gap < arr.Count; i++)
                {
                    var j = i + gap;
                    var tmp = arr[j];
                    while (j - gap >= 0 && tmp.CompareTo(arr[j - gap]) < 0)
                    {
                        arr[j] = arr[j - gap];
                        j -= gap;
                    }

                    arr[j] = tmp;
                }

                gap /= 2;
            }

            return arr;
        }
    }
}