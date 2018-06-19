using System;
using DSA.BLL.DataStructures.LinkedList.SinglyLinkedList;

namespace DSA.BLL.DataStructures.Queue
{
    public class ListQueue<T> : SinglyLinkedList<T>, IQueue<T>
    {
        public ListQueue()
        {
        }

        public ListQueue(int count)
        {
            for (var i = 0; i < count; i++) Add(default(T));
        }

        public int Index { get; private set; }


        public bool IsEmpty => Index <= 0;
        public bool IsFull => false;

        public override void Clear()
        {
            base.Clear();
            Index = 0;
        }

        public virtual void Enqueue(T item)
        {
            Add(item);
            Index++;
        }

        public virtual T Dequeue()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Queue is empty.");
            var res = this[0];
            RemoveAt(0);
            Index--;
            return res;
        }

        public virtual T Peek()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Queue is empty.");
            return this[0];
        }

        public override void Reverse(int startIndex = 0, int endIndex = 0)
        {
            base.Reverse(startIndex, Index - 1);
        }
    }
}