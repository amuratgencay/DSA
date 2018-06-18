using System;
using System.Collections.Generic;

namespace DSA.BLL.DataStructures.LinkedList.CircularLinkedList
{
    public class CircularLinkedCountable<T> : LinkedCountable<T>
    {
        private DoublyNode<T> _first, _last;

        public override T this[int index]
        {
            get
            {
                if (index >= Count)
                    throw new IndexOutOfRangeException("Index grater or equal count.");
                var item = _first;
                for (var i = 0; i < index; i++) item++;
                return item.Item;
            }
            set
            {
                if (index >= Count)
                    throw new IndexOutOfRangeException("Index grater or equal count.");
                var item = _first;
                for (var i = 0; i < index; i++) item++;

                item.Item = value;
            }
        }

        public override void Add(T item)
        {
            var n = new DoublyNode<T>(item);

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

            Count++;
        }

        public override void Insert(int index, T item)
        {
            if (index >= Count)
                throw new IndexOutOfRangeException("Index grater or equal count.");
            var p = _first;
            var prev = _first;
            var n = new DoublyNode<T>(item);
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

            Count++;
        }

        public override bool RemoveAt(int index)
        {
            if (index >= Count)
                throw new IndexOutOfRangeException("Index grater or equal count.");
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

            Count--;
            return true;
        }

        public override bool Contains(T item)
        {
            var p = _first;
            for (var i = 0; i < Count; i++)
            {
                if (p.Item.Equals(item))
                    return true;
                p++;
            }

            return false;
        }

        public override int IndexOf(T item)
        {
            var p = _first;
            for (var i = 0; i < Count; i++)
            {
                if (p.Item.Equals(item))
                    return i;
                p++;
            }

            return -1;
        }

        public override void Reverse()
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

        public override void Clear()
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
            Count = 0;
        }

        public override IEnumerable<T> GetEnumerable()
        {
            var p = _first;
            for (var i = 0; i < Count; i++)
            {
                yield return p.Item;
                p++;
            }
        }
    }
}