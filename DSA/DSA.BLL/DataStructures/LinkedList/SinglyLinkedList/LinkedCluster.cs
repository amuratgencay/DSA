using System;
using System.Collections.Generic;
using System.Linq;
using DSA.Entity.DataStructures;

namespace DSA.BLL.DataStructures.LinkedList.SinglyLinkedList
{
    public class LinkedCluster<T> : ICluster<T>
    {
        private Node<T> _first, _last;

        public void Add(T item)
        {
            if (_first == null)
            {
                _first = _last = new Node<T>(item);
            }
            else
            {
                _last.Next = new Node<T>(item);
                _last = _last.Next;
            }

            Count++;
        }

        public void Insert(int index, T item)
        {
            if (index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index), "index grater or equal count");
            var p = _first;
            var prev = _first;
            for (var i = 0; i < index; i++)
            {
                prev = p;
                p++;
            }

            if (p == _first)
            {
                p.Next = _first;
                _first = p;
            }
            else if (p == _last)
            {
                _last.Next = p;
                _last = p;
            }
            else
            {
                prev.Next = new Node<T>(item);
                prev.Next.Next = p;
            }

            Count++;
        }

        public bool Remove(T item)
        {
            return RemoveAt(IndexOf(item));
        }

        public bool RemoveAt(int index)
        {
            if (index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index), "index grater or equal count");
            var item = _first;
            var prev = _first;
            for (var i = 0; i < index; i++)
            {
                prev = item;
                item++;
            }

            if (item == _first)
            {
                _first = _first.Next;
            }
            else if (item == _last)
            {
                prev.Next = null;
                _last = prev;
            }
            else
            {
                prev.Next = item.Next;
                item.Next = null;
            }

            Count--;
            return true;
        }

        public bool Contains(T item)
        {
            for (var i = _first; i != null; i++)
                if (i.Item.Equals(item))
                    return true;
            return false;
        }

        public int IndexOf(T item)
        {
            var res = -1;
            for (var i = _first; i != null; i++)
            {
                res++;
                if (i.Item.Equals(item))
                    return res;
            }

            return -1;
        }

        public void Reverse()
        {
            for (int i = 0, j = Count - 1; i < j; i++, j--)
            {
                var p = _first;
                for (var k = 0; k < i; k++) p++;

                var q = _first;
                for (var k = 0; k < j; k++) q++;

                var tmp = p.Item;
                p.Item = q.Item;
                q.Item = tmp;
            }
        }

        public void Clear()
        {
            for (var i = _first; i != null; i++)
            {
                var item = i.Next;
                i.Next = null;
                i = item;
            }

            _first = _last = null;
            Count = 0;
        }

        public IEnumerable<T> ToEnumerable()
        {
            for (var i = _first; i != null; i++) yield return i.Item;
        }

        public T this[int index]
        {
            get
            {
                if (index >= Count)
                    throw new ArgumentOutOfRangeException(nameof(index), "index grater or equal count");
                var item = _first;
                for (var i = 0; i < index; i++) item++;
                return item.Item;
            }
            set
            {
                if (index >= Count)
                    throw new ArgumentOutOfRangeException(nameof(index), "index grater or equal count");
                var item = _first;
                for (var i = 0; i < index; i++) item++;

                item.Item = value;
            }
        }

        public int Count { get; private set; }

        public override string ToString()
        {
            return "{ " + ToEnumerable().Aggregate("", (x, y) => x + (!string.IsNullOrEmpty(x) ? ", " : "") + y) + " }";
        }

        private class Node<T>
        {
            public Node(T item)
            {
                Item = item;
            }

            public T Item { get; set; }
            public Node<T> Next { get; set; }

            public static Node<T> operator ++(Node<T> node)
            {
                if (node == null)
                    throw new ArgumentNullException(nameof(node));
                return node?.Next;
            }
        }
    }
}