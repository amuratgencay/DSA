using System;
using DSA.BLL.DataStructures.LinkedList.SinglyLinkedList;

namespace DSA.BLL.DataStructures.Stack
{
    public class ListStack<T> : SinglyLinkedList<T>, IStack<T>
    {
        public ListStack()
        {
        }

        public ListStack(int count)
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

        public virtual void Push(T item)
        {
            Add(item);
            Index++;
        }

        public virtual T Pop()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Stack is empty.");
            Index--;
            var res = this[Index];
            RemoveAt(Index);
            return res;
        }

        public virtual T Peek()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Stack is empty.");
            return this[0];
        }

        public override void Reverse(int startIndex = 0, int endIndex = 0)
        {
            base.Reverse(startIndex, Index - 1);
        }
    }
}