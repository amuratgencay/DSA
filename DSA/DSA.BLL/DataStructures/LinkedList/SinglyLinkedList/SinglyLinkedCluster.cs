using System;
using System.Collections.Generic;

namespace DSA.BLL.DataStructures.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedCluster<T> : LinkedCluster<T>
    {
        private SinglyNode<T> _first, _last;

        public override T this[int index]
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

        public override void Add(T item)
        {
            var n = new SinglyNode<T>(item);
            if (_first == null)
            {
                _first = _last = n;
            }
            else
            {
                _last.Next = n;
                _last = _last.Next;
            }

            _count++;
        }

        public override void Insert(int index, T item)
        {
            if (index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index), "index grater or equal count");
            var p = _first;
            var prev = _first;
            var n = new SinglyNode<T>(item);
            for (var i = 0; i < index; i++)
            {
                prev = p;
                p++;
            }

            if (p == _first)
            {
                n.Next = _first;
                _first = n;
            }
            else if (p == _last)
            {
                _last.Next = n;
                _last = n;
            }
            else
            {
                prev.Next = n;
                n.Next = p;
            }

            _count++;
        }

        public override bool RemoveAt(int index)
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

            _count--;
            return true;
        }

        public override bool Contains(T item)
        {
            for (var i = _first; i != null; i++)
                if (i.Item.Equals(item))
                    return true;
            return false;
        }

        public override int IndexOf(T item)
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

        public override void Reverse()
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

        public override void Clear()
        {
            for (var i = _first; i != null; i++)
            {
                var item = i.Next;
                i.Next = null;
                i = item;
            }

            _first = _last = null;
            _count = 0;
        }

        public override IEnumerable<T> ToEnumerable()
        {
            for (var i = _first; i != null; i++) yield return i.Item;
        }
    }
}