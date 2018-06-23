using System;
using System.Collections.Generic;

namespace DSA.BLL.DataStructures
{
    public interface ICountable<T> : ICloneable
    {
        T this[int index] { get; set; }
        int Count { get; }
        void Clear();
        bool Contains(T item);
        int IndexOf(T item, int startIndex = 0);
        int LastIndexOf(T item, int startIndex = 0);
        void Reverse(int startIndex = 0, int endIndex = 0);
        IEnumerable<T> GetEnumerable();
    }
}