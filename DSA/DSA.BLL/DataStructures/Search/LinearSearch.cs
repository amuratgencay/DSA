using System;
using System.Linq;

namespace DSA.BLL.DataStructures.Search
{
    public class LinearSearch<T>
    {
        public T Search(ICountable<T> array, T item)
        {
            for (var i = 0; i < array.Count; i++)
                if (array[i].Equals(item))
                    return array[i];
            return default(T);
        }
    }

    public class BinarySearch<T> where T : IComparable<T>
    {
        public T Search(ICountable<T> array, T item)
        {
            var arr = array.GetEnumerable().OrderBy(x => x).ToList();
            var lower = 0;
            var upper = arr.Count;
            var mid = 0;
            while (lower < upper)
            {
                mid = lower + (upper - lower) / 2;
                if (arr[mid].CompareTo(item) < 0)
                    lower = mid + 1;
                else if (arr[mid].CompareTo(item) > 0)
                    upper = mid - 1;
                else
                    return arr[mid];
            }

            if (lower == upper && arr[lower].CompareTo(item) == 0) return arr[lower];
            return default(T);
        }
    }

    public class InterpolationSearch
    {
        public int Search(ICountable<int> array, int item)
        {
            var arr = array.GetEnumerable().OrderBy(x => x).ToList();
            var lower = 0;
            var upper = arr.Count - 1;
            var mid = -1;
            while (lower < upper)
            {
                mid = lower + (upper - lower) / (arr[upper] - arr[lower]) * (item - arr[lower]);
                if (arr[mid].CompareTo(item) < 0)
                    lower = mid + 1;
                else if (arr[mid].CompareTo(item) > 0)
                    upper = mid - 1;
                else
                    return arr[mid];
            }

            if (lower == upper && arr[lower].CompareTo(item) == 0) return arr[lower];
            return 0;
        }
    }
}