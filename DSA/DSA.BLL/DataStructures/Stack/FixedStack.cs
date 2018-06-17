using System;
using System.Collections.Generic;

namespace DSA.BLL.DataStructures.Stack
{
    public class FixedStack<T> : Stack<T>
    {
        private readonly T[] _array;

        public FixedStack()
        {
            _array = new T[Count];
        }

        public FixedStack(int count)
        {
            Count = count;
            _array = new T[Count];
        }

        public override T this[int index]
        {
            get
            {
                if (index >= Count)
                    throw new IndexOutOfRangeException("Index grater or equal count.");
                return _array[index];
            }
            set
            {
                if (index >= Count)
                    throw new IndexOutOfRangeException("Index grater or equal count.");
                _array[index] = value;
            }
        }

        public override bool Contains(T item)
        {
            for (var i = 0; i < Count; i++)
                if (_array[i].Equals(item))
                    return true;
            return false;
        }

        public override int IndexOf(T item)
        {
            for (var i = 0; i < Count; i++)
                if (_array[i].Equals(item))
                    return i;
            return -1;
        }

        public override void Reverse()
        {
            for (int i = 0, j = Count - 1; i < j; i++, j--)
            {
                var tmp = _array[i];
                _array[i] = _array[j];
                _array[j] = tmp;
            }
        }

        public override void Clear()
        {
            for (var i = 0; i < Count; i++) _array[i] = default(T);
            Index = 0;
        }

        public override IEnumerable<T> ToEnumerable()
        {
            for (var i = 0; i < Count; i++) yield return _array[i];
        }

        public override void Push(T item)
        {
            if (IsFull)
                throw new IndexOutOfRangeException("Stack is full.");

            _array[Index++] = item;
        }

        public override T Pop()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Stack is empty.");
            Index--;

            var res = _array[Index];
            _array[Index] = default(T);

            return res;
        }

        public override T Peek()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Stack is empty.");
            return _array[0];
        }
    }
}