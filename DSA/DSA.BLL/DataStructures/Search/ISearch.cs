namespace DSA.BLL.DataStructures.Search
{
    public interface ISearch<T>
    {
        T Search(ICountable<T> array, T item);
    }
}