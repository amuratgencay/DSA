using DSA.BLL.DataStructures.LinkedList.SinglyLinkedList;
using DSA.BLL.DataStructures.Queue;
using System;
using System.Collections.Generic;

namespace DSA.BLL.DataStructures.Stack
{
    public class ExpandedQueue<T> : DSA.BLL.DataStructures.Queue.Queue<T>
    {
        private readonly SinglyLinkedCluster<T> _list;

        public ExpandedQueue()
        {
            _list = new SinglyLinkedCluster<T>();
            Count = 0;
        }

        public ExpandedQueue(int count)
        {
            _list = new SinglyLinkedCluster<T>();
            for (var i = 0; i < count; i++) _list.Add(default(T));
            Count = count;

        }

        public override T this[int index]
        {
            get => _list[index];
            set => _list[index] = value;
        }


        public override bool Contains(T item)
        {
            return _list.Contains(item);
        }

        public override int IndexOf(T item)
        {
            return _list.IndexOf(item);
        }

        public override void Reverse()
        {
            _list.Reverse();
        }

        public override void Clear()
        {
            _list.Clear();
            Count = 0;
        }

        public override IEnumerable<T> ToEnumerable()
        {
            return _list.ToEnumerable();
        }

        public override void Enqueue(T item)
        {
            _list.Add(item);
            Index++;
            Count++;

        }

        public override T Dequeue()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Stack is empty.");
            var res = _list[0];
            _list.RemoveAt(0);
            Index--;
            Count--;
            return res;
        }

        public override T Peek()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Stack is empty.");
            return _list[0];
        }
    }
}