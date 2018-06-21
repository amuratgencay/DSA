using System;
using System.Collections.Generic;
using System.Linq;

namespace DSA.BLL.DataStructures.LinkedList
{
    public enum ListItemWay
    {
        Next,
        Prev,
        Up,
        Sub,
        Top
    }

    public class ListItem<T> : IDisposable
    {
        public ListItem(T item)
        {
            Value = item;
            LinksItems = new Dictionary<ListItemWay, ListItem<T>>();
        }

        public T Value { get; set; }

        public ListItem<T> this[ListItemWay way]
        {
            get
            {
                return LinksItems.ContainsKey(way) ? LinksItems[way] : null;
            }
            set
            {
                if (LinksItems.ContainsKey(way))
                    LinksItems[way] = value;
                else
                    LinksItems.Add(way, value);
            }
        }



        protected Dictionary<ListItemWay, ListItem<T>> LinksItems { get; set; }

        public void Dispose()
        {
            ClearRecursive(this);
        }

        public void Clear()
        {
            LinksItems.Clear();
            Value = default(T);
        }

        private static void ClearRecursive(ListItem<T> item)
        {
            if (item == null)
                return;
            var q = item.LinksItems.Select(x => x.Value);
            item.Clear();
            foreach (var listItem in q) ClearRecursive(listItem);
        }

        public static ListItem<T> operator ++(ListItem<T> item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            return item[ListItemWay.Next];
        }
    }

    public class SinglyListItem<T> : ListItem<T>
    {
        public SinglyListItem(T item) : base(item)
        {
        }

        public SinglyListItem<T> Next
        {
            get => (SinglyListItem<T>) LinksItems[ListItemWay.Next];
            set => LinksItems[ListItemWay.Next] = value;
        }

        public static SinglyListItem<T> operator ++(SinglyListItem<T> item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            return item.Next;
        }
    }

    public class DoublyListItem<T> : ListItem<T>
    {
        public DoublyListItem(T item) : base(item)
        {
        }

        public DoublyListItem<T> Next
        {
            get => (DoublyListItem<T>) LinksItems[ListItemWay.Next];
            set => LinksItems[ListItemWay.Next] = value;
        }

        public DoublyListItem<T> Prev
        {
            get => (DoublyListItem<T>) LinksItems[ListItemWay.Prev];
            set => LinksItems[ListItemWay.Prev] = value;
        }

        public static DoublyListItem<T> operator ++(DoublyListItem<T> item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            return item.Next;
        }
    }

    public abstract class LinkedList<T> : ICountable<T>
    {
        protected ListItem<T> First, Last;

        public virtual T this[int index]
        {
            get
            {
                if (index >= Count)
                    throw new IndexOutOfRangeException("Index grater or equal count.");
                var item = First;
                for (var i = 0; i < index; i++) item++;
                return item.Value;
            }
            set
            {
                if (index >= Count)
                    throw new IndexOutOfRangeException("Index grater or equal count.");
                var item = First;
                for (var i = 0; i < index; i++) item++;

                item.Value = value;
            }
        }

        public virtual int Count { get; protected set; }

        public virtual void Clear()
        {
            First.Dispose();
            First = Last = null;
            Count = 0;
        }

        public virtual bool Contains(T item)
        {
            var p = First;
            for (var i = 0; i < Count; i++)
            {
                if (p.Value.Equals(item)) return true;

                p++;
            }

            return false;
        }

        public virtual int IndexOf(T item, int startIndex = 0)
        {
            var p = First;
            for (var i = startIndex; i < Count; i++)
            {
                if (p.Value.Equals(item)) return i;

                p++;
            }

            return -1;
        }

        public virtual int LastIndexOf(T item, int startIndex = 0)
        {
            if (startIndex == 0)
                startIndex = Count - 1;
            var p = First;
            for (var i = startIndex; i >= 0; i--)
            {
                var q = First;
                for (var j = 0; j < i; j++) q++;

                if (q.Value.Equals(item)) return i;

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
                var p = First;
                for (var k = 0; k < i; k++) p++;

                var q = First;
                for (var k = 0; k < j; k++) q++;

                var tmp = p.Value;
                p.Value = q.Value;
                q.Value = tmp;
            }
        }

        public virtual IEnumerable<T> GetEnumerable()
        {
            var p = First;
            for (var i = 0; i < Count; i++)
            {
                yield return p.Value;
                p++;
            }
        }

        public override string ToString()
        {
            return $"( {GetEnumerable().Aggregate("", (x, y) => x + (!string.IsNullOrEmpty(x) ? ", " : "") + y)} )";
        }

        protected virtual void Add(ListItem<T> item)
        {
            if (First == null)
            {
                First = Last = item;
            }
            else
            {
                Last[ListItemWay.Next] = item;
                Last++;
            }

            Count++;
        }

        protected virtual void Insert(int index, ListItem<T> item)
        {
            if (index >= Count)
                throw new IndexOutOfRangeException("Index grater or equal count.");
            var p = First;
            var prev = First;
            for (var i = 0; i < index; i++)
            {
                prev = p;
                p++;
            }

            if (p == First)
            {
                item[ListItemWay.Next] = First;
                First = item;
            }
            else if (p == Last)
            {
                Last[ListItemWay.Next] = item;
                Last = item;
            }
            else
            {
                prev[ListItemWay.Next] = item;
                item[ListItemWay.Next] = p;
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
            var item = First;
            var prev = First;
            for (var i = 0; i < index; i++)
            {
                prev = item;
                item++;
            }

            if (item == First)
            {
                var first = First;
                First++;
                first.Clear();
            }
            else if (item == Last)
            {
                prev[ListItemWay.Next] = null;
                Last = prev;
            }
            else
            {
                prev[ListItemWay.Next] = item[ListItemWay.Next];
                item[ListItemWay.Next] = null;
            }

            Count--;
            return true;
        }
    }
}