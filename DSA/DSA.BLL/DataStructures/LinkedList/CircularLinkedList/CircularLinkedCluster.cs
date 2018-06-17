using System;
using System.Collections.Generic;
using System.Linq;
using DSA.Entity.DataStructures;

namespace DSA.BLL.DataStructures.LinkedList.CircularLinkedList
{
    public class CircularLinkedCluster<T> : ICluster<T>
    {
        private int _count;
        private Node<T> _first, _last;

        public void Add(T item)
        {
            var n = new Node<T>(item);

            if (_first == null)
            {
                _first = _last = n;
            }
            else
            {
                _last.Next = n;
                _last.Next.Prev = _last;
                _last = _last.Next;
            }

            _last.Next = _first;
            _first.Prev = _last;

            _count++;
        }

        public void Insert(int index, T item)
        {
            if (index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index), "index grater or equal count");
            var p = _first;
            var prev = _first;
            var n = new Node<T>(item);
            for (var i = 0; i < index; i++)
            {
                prev = p;
                p++;
            }

            if (p == _first)
            {
                n.Next = _first;
                n.Next.Prev = n;
                _first = n;

                _last.Next = _first;
                _first.Prev = _last;
            }
            else if (p == _last)
            {
                _last.Next = n;
                _last.Next.Prev = _last;
                _last = n;

                _last.Next = _first;
                _first.Prev = _last;
            }
            else
            {
                prev.Next = n;
                n.Next = p;
            }

            _count++;
        }

        public bool Remove(T item)
        {
            return RemoveAt(IndexOf(item));
        }

        public bool RemoveAt(int index)
        {
            if (index >= _count)
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
                _first.Prev = _last;
                _last.Next = _first;
            }
            else if (item == _last)
            {
                _last.Prev = null;
                prev.Next = null;
                _last = prev;
                _last.Next = _first;
            }
            else
            {
                prev.Next = item.Next;
                item.Next = null;
                item.Prev = null;
            }

            _count--;
            return true;
        }

        public bool Contains(T item)
        {
            var p = _first;
            for (var i = 0; i < _count; i++)
            {
                if (p.Item.Equals(item))
                    return true;
                p++;
            }

            return false;
        }

        public int IndexOf(T item)
        {
            var p = _first;
            for (var i = 0; i < _count; i++)
            {
                if (p.Item.Equals(item))
                    return i;
                p++;
            }

            return -1;
        }

        public void Reverse()
        {
            for (int i = 0, j = _count - 1; i < j; i++, j--)
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
            var p = _first;

            while (p != null)
            {
                var item = p.Next;
                p.Next = null;
                p.Prev = null;
                p = item;
            }

            _first = _last = null;
            _count = 0;
        }

        public IEnumerable<T> ToEnumerable()
        {
            var p = _first;
            for (var i = 0; i < _count; i++)
            {
                yield return p.Item;
                p++;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index >= _count)
                    throw new ArgumentOutOfRangeException(nameof(index), "index grater or equal count");
                var item = _first;
                for (var i = 0; i < index; i++) item++;
                return item.Item;
            }
            set
            {
                if (index >= _count)
                    throw new ArgumentOutOfRangeException(nameof(index), "index grater or equal count");
                var item = _first;
                for (var i = 0; i < index; i++) item++;

                item.Item = value;
            }
        }

        public int Count()
        {
            return _count;
        }

        public override string ToString()
        {
            return "{ " + ToEnumerable().Aggregate("", (x, y) => x + (!string.IsNullOrEmpty(x) ? ", " : "") + y) + " }";
        }

        private class Node<TInner>
        {
            public Node(TInner item)
            {
                Item = item;
            }

            public TInner Item { get; set; }
            public Node<TInner> Next { get; set; }
            public Node<TInner> Prev { get; set; }

            public static Node<TInner> operator ++(Node<TInner> node)
            {
                if (node == null)
                    throw new ArgumentNullException(nameof(node));
                return node?.Next;
            }
        }
    }
}