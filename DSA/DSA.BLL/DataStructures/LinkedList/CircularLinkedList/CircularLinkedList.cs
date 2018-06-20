using System;
using System.Collections.Generic;
using System.Linq;

namespace DSA.BLL.DataStructures.LinkedList.CircularLinkedList
{
    public class CircularLinkedList<T> : ICountable<T>
    {
        private DoublyLinkedListItem<T> _first, _last;

        public virtual T this[int index]
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

        public virtual bool Contains(T item)
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

        public virtual int IndexOf(T item)
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

        public virtual void Reverse(int startIndex = 0, int endIndex = 0)
        {
            if (startIndex >= Count || startIndex < 0)
                startIndex = 0;
            if (endIndex >= Count || endIndex <= 0)
                endIndex = Count - 1;
            if (startIndex >= endIndex)
            {
                startIndex = 0;
                endIndex = Count - 1;
            }

            for (int i = startIndex, j = endIndex; i < j; i++, j--)
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

        public int Count { get; protected set; }

        public virtual void Clear()
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

        public virtual IEnumerable<T> GetEnumerable()
        {
            var p = _first;
            for (var i = 0; i < Count; i++)
            {
                yield return p.Item;
                p++;
            }
        }

        public virtual void Add(T item)
        {
            var n = new DoublyLinkedListItem<T>(item);

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

        public virtual void Insert(int index, T item)
        {
            if (index >= Count)
                throw new IndexOutOfRangeException("Index grater or equal count.");
            var p = _first;
            var prev = _first;
            var n = new DoublyLinkedListItem<T>(item);
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

        public virtual bool Remove(T item)
        {
            return RemoveAt(IndexOf(item));
        }

        public virtual bool RemoveAt(int index)
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

        public override string ToString()
        {
            return "{ " + GetEnumerable().Aggregate("", (x, y) => x + (!string.IsNullOrEmpty(x) ? ", " : "") + y) +
                   " }";
        }
    }
}