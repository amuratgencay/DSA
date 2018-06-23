using System;
using System.Linq;

namespace DSA.BLL.DataStructures.Search
{
    public class InterpolationSearch<T> : ISearch<T> where T : IComparable
    {
        public T Search(ICountable<T> array, T item)
        {
            var arr = array.GetEnumerable().OrderBy(x => x).ToList();
            var lower = 0;
            var upper = arr.Count - 1;
            var mid = -1;
            while (lower < upper)
            {
                mid = lower + (upper - lower) /
                      (Math.Abs(arr[upper].GetHashCode()) - Math.Abs(arr[lower].GetHashCode())) *
                      (Math.Abs(item.GetHashCode()) - Math.Abs(arr[lower].GetHashCode()));
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
}