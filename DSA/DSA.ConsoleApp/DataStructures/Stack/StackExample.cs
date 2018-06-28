using System;
using DSA.BLL.DataStructures.Stack;
using DSA.ConsoleApp.DataStructures.Example;

namespace DSA.ConsoleApp.DataStructures.Stack
{
    public class StackExample : ExtendedCountableExample<int>
    {
        private static IStack<int> _stack;

        public StackExample(IStack<int> stack) : base(stack, 5, 8, 13, 13, 1, 21, 2, FirstInit, SecondInit)
        {
            _stack = stack;
        }

        public static void FirstInit()
        {
            _stack.Push(2);
            _stack.Push(3);
            _stack.Push(5);
            _stack.Push(8);
            _stack.Push(13);
            Console.WriteLine("\tInit -> " + _stack);
        }

        public static void SecondInit()
        {
            _stack.Push(21);
            _stack.Push(8);
            _stack.Push(5);
            _stack.Push(13);

            Console.WriteLine("\tInit -> " + _stack);
        }

        public override void TakeExample()
        {
            Console.WriteLine("\tPop -> " + _stack.Pop());
        }

        public override void GetFirstExample()
        {
            Console.WriteLine("\tPeek -> " + _stack.Peek());
        }

        public override void IsFullExample()
        {
            Console.WriteLine("\tIsFull -> " + _stack.IsFull);
        }

        public override void IsEmptyExample()
        {
            Console.WriteLine("\tIsEmpty -> " + _stack.IsEmpty);
        }

    }

    public class ArrayStackExample : StackExample
    {
        public ArrayStackExample() : base(new ArrayStack<int>(5))
        {
        }
    }

    public class VectorStackExample : StackExample
    {
        public VectorStackExample() : base(new VectorStack<int>())
        {
        }
    }

    public class ListStackExample : StackExample
    {
        public ListStackExample() : base(new ListStack<int>(5))
        {
        }
    }
}