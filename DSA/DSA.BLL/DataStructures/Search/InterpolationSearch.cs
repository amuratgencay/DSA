using System.Linq;

namespace DSA.BLL.DataStructures.Search
{
    public class InterpolationSearch : ISearch<int>
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