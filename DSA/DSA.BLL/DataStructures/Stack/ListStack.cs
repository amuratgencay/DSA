using System;
using System.Collections.Generic;
using DSA.BLL.DataStructures.LinkedList.SinglyLinkedList;

namespace DSA.BLL.DataStructures.Stack
{
    public class ListStack<T> : IStack<T>
    {
        protected SinglyLinkedList<T> list;
        protected int index;

        public ListStack()
        {
            list = new SinglyLinkedList<T>();
        }

        public ListStack(int count)
        {
            for (var i = 0; i < count; i++) list.Add(default(T));
        }

        


        public bool IsEmpty => index <= 0;
        public bool IsFull => false;

        public int Count => list.Count;

        public T this[int index] { get => list[index]; set => list[index] = value; }

        public  void Clear()
        {
            list.Clear();
            index = 0;
        }

        public virtual void Push(T item)
        {
            list.Add(item);
            index++;
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Stack is empty.");
            index--;
            var res = this[index];
            list.RemoveAt(index);
            return res;
        }

        public virtual T Peek()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Stack is empty.");
            return this[0];
        }

        public void Reverse(int startIndex = 0, int endIndex = 0)
        {
            list.Reverse(startIndex, index - 1);
        }

        public bool Contains(T item) => list.Contains(item);

        public int IndexOf(T item) => list.IndexOf(item);

        public IEnumerable<T> GetEnumerable() => list.GetEnumerable();

        public override string ToString() => list.ToString();
    }
}