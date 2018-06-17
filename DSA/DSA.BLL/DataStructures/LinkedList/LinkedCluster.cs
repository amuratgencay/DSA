using System;
using System.Collections.Generic;
using System.Linq;

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

    public class DoublyNode<T> : Node<T>
    {
        public DoublyNode(T item) : base(item)
        {
        }

        public DoublyNode<T> Next { get; set; }
        public DoublyNode<T> Prev { get; set; }

        public static DoublyNode<T> operator ++(DoublyNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));
            return node?.Next;
        }
    }

    public abstract class LinkedCluster<T> : IExpandedCluster<T>
    {
        public abstract T this[int index] { get; set; }

        public int Count { get; protected set; }

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