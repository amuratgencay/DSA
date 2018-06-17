using System.Collections.Generic;

namespace DSA.Entity.DataStructures
{
    public interface ICluster<T>
    {
        T this[int index] { get; set; }
        int Count();
        bool Contains(T item);
        int IndexOf(T item);
        void Reverse();
        void Clear();
        IEnumerable<T> ToEnumerable();
    }

    public interface IExpandedCluster<T> : ICluster<T>
    {
        void Add(T item);
        void Insert(int index, T item);
        bool Remove(T item);
        bool RemoveAt(int index);
    }
}