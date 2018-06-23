using System;
using System.Collections.Generic;
using DSA.BLL.DataStructures.LinkedList.SinglyLinkedList;

namespace DSA.BLL.DataStructures.Stack
{
    public class ListStack<T> : IStack<T>
    {
        protected int Index;
        protected SinglyLinkedList<T> List;

        public ListStack()
        {
            List = new SinglyLinkedList<T>();
        }

        public ListStack(int count)
        {
            List = new SinglyLinkedList<T>();
            for (var i = 0; i < count; i++) List.Add(default(T));
        }


        public bool IsEmpty => Index <= 0;
        public bool IsFull => false;

        public int Count => List.Count;

        public T this[int index]
        {
            get => List[index];
            set => List[index] = value;
        }

        public void Clear()
        {
            List.Clear();
            Index = 0;
        }

        public virtual void Push(T item)
        {
            List.Add(item);
            Index++;
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Stack is empty.");
            Index--;
            var res = this[Index];
            List.RemoveAt(Index);
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
            List.Reverse(startIndex, Index - 1);
        }

        public bool Contains(T item)
        {
            return List.Contains(item);
        }

        public int IndexOf(T item, int startIndex = 0)
        {
            return List.IndexOf(item, startIndex);
        }

        public int LastIndexOf(T item, int startIndex = 0)
        {
            return List.LastIndexOf(item, startIndex);
        }

        public IEnumerable<T> GetEnumerable()
        {
            return List.GetEnumerable();
        }

        public object Clone()
        {
            return new ListStack<T>(Count)
            {
                List = (SinglyLinkedList<T>) List.Clone(),
                Index = Index
            };
        }

        public override string ToString()
        {
            return List.ToString();
        }
    }
}