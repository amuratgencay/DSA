namespace DSA.BLL.DataStructures.Search
{
    public class LinearSearch<T> : ISearch<T>
    {
        public T Search(ICountable<T> array, T item)
        {
            for (var i = 0; i < array.Count; i++)
                if (array[i].Equals(item))
                    return array[i];
            return default(T);
        }
    }
}