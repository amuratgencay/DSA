using System;

namespace DSA.BLL.DataStructures.Sort
{
    public class SelectionSort<T> : ISort<T> where T : IComparable
    {
        public ICountable<T> Sort(ICountable<T> array)
        {
            var arr = (ICountable<T>) array.Clone();
            for (var i = 0; i < arr.Count - 1; i++)
            {
                var min = i;
                for (var j = i + 1; j < arr.Count; j++)
                    if (arr[j].CompareTo(arr[min]) < 0)
                        min = j;

                var tmp = arr[i];
                arr[i] = arr[min];
                arr[min] = tmp;
            }

            return arr;
        }
    }
}