using System;
using System.Collections.Generic;
using DSA.BLL.DataStructures.LinkedList.SinglyLinkedList;

namespace DSA.BLL.DataStructures.Queue
{
    public class ListQueue<T> : IQueue<T>
    {
        protected int index;
        protected SinglyLinkedList<T> list;

        public ListQueue()
        {
            list = new SinglyLinkedList<T>();
        }

        public ListQueue(int count)
        {
            list = new SinglyLinkedList<T>();
            for (var i = 0; i < count; i++) list.Add(default(T));
        }


        public bool IsEmpty => index <= 0;
        public bool IsFull => false;

        public int Count => list.Count;

        public T this[int index]
        {
            get => list[index];
            set => list[index] = value;
        }

        public void Clear()
        {
            list.Clear();
            index = 0;
        }

        public void Enqueue(T item)
        {
            list.Add(item);
            index++;
        }

        public T Dequeue()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Queue is empty.");
            var res = this[0];
            list.RemoveAt(0);
            index--;
            return res;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Queue is empty.");
            return this[0];
        }

        public int LastIndexOf(T item, int startIndex = 0)
        {
            throw new NotImplementedException();
        }

        public void Reverse(int startIndex = 0, int endIndex = 0)
        {
            list.Reverse(startIndex, index - 1);
        }

        public bool Contains(T item)
        {
            return list.Contains(item);
        }

        public int IndexOf(T item, int startIndex = 0)
        {
            return list.IndexOf(item);
        }


        public IEnumerable<T> GetEnumerable()
        {
            return list.GetEnumerable();
        }

        public override string ToString()
        {
            return list.ToString();
        }
    }
}