using System;
using System.Collections.Generic;
using DSA.BLL.DataStructures.LinkedList.SinglyLinkedList;

namespace DSA.BLL.DataStructures.Stack
{
    public class ExpandedStack<T> : Stack<T>
    {
        private readonly SinglyLinkedCluster<T> _list;

        public ExpandedStack()
        {
            _list = new SinglyLinkedCluster<T>();
        }

        public ExpandedStack(int count)
        {
            _list = new SinglyLinkedCluster<T>();
            for (var i = 0; i < count; i++) _list.Add(default(T));
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
        }

        public override IEnumerable<T> ToEnumerable()
        {
            return _list.ToEnumerable();
        }

        public override void Push(T item)
        {
            _list.Add(item);
            Index++;
        }

        public override T Pop()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Stack is empty.");
            var res = _list[_list.Count - 1];
            _list.RemoveAt(_list.Count - 1);
            Index--;
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