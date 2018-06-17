using System;
using System.Collections.Generic;
using System.Linq;
using DSA.Entity.DataStructures;

namespace DSA.BLL.DataStructures.LinkedList
{
    public abstract class Node<T>
    {
        protected Node(T item)
        {
            Item = item;
        }

        public T Item { get; set; }
    }

    public class SinglyNode<T> : Node<T>
    {
        public SinglyNode(T item) : base(item)
        {
        }

        public SinglyNode<T> Next { get; set; }

        public static SinglyNode<T> operator ++(SinglyNode<T> singlyNode)
        {
            if (singlyNode == null)
                throw new ArgumentNullException(nameof(singlyNode));
            return singlyNode?.Next;
        }
    }

    public class DoublySinglyNode<T> : Node<T>
    {
        public DoublySinglyNode(T item) : base(item)
        {
        }

        public DoublySinglyNode<T> Next { get; set; }
        public DoublySinglyNode<T> Prev { get; set; }

        public static DoublySinglyNode<T> operator ++(DoublySinglyNode<T> singlyNode)
        {
            if (singlyNode == null)
                throw new ArgumentNullException(nameof(singlyNode));
            return singlyNode?.Next;
        }
    }

    public abstract class LinkedCluster<T> : IExpandedCluster<T>
    {
        protected int _count;
        public abstract T this[int index] { get; set; }

        public int Count()
        {
            return _count;
        }

        public abstract bool Contains(T item);
        public abstract int IndexOf(T item);
        public abstract void Reverse();
        public abstract void Clear();
        public abstract IEnumerable<T> ToEnumerable();
        public abstract void Add(T item);
        public abstract void Insert(int index, T item);

        public bool Remove(T item)
        {
            return RemoveAt(IndexOf(item));
        }

        public abstract bool RemoveAt(int index);

        public override string ToString()
        {
            return "{ " + ToEnumerable().Aggregate("", (x, y) => x + (!string.IsNullOrEmpty(x) ? ", " : "") + y) + " }";
        }
    }
}