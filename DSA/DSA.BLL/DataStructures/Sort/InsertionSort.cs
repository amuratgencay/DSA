using System;

namespace DSA.BLL.DataStructures.Sort
{
    public class InsertionSort<T> : ISort<T> where T : IComparable
    {
        public ICountable<T> Sort(ICountable<T> array)
        {
            var arr = (ICountable<T>) array.Clone();
            for (var i = 1; i < arr.Count; i++)
            {
                var insert = arr[i];
                var pos = i;
                while (pos > 0 && arr[pos - 1].CompareTo(insert) > 0)
                {
                    arr[pos] = arr[pos - 1];
                    pos--;
                }

                arr[pos] = insert;
            }

            return arr;
        }
    }
}