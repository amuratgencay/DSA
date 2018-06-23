using System;

namespace DSA.BLL.DataStructures.Sort
{
    public interface ISort<T> where T : IComparable
    {
        ICountable<T> Sort(ICountable<T> arr);
    }
}