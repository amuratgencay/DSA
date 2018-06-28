using System;
using DSA.BLL.DataStructures.Queue;
using DSA.ConsoleApp.DataStructures.Example;

namespace DSA.ConsoleApp.DataStructures.Queue
{
    public class QueueExample : ExtendedCountableExample<int>
    {
        private static IQueue<int> _queue;

        public QueueExample(IQueue<int> stack) : base(stack, 5, 8, 13, 13, 1, 21, 2, FirstInit, SecondInit)
        {
            _queue = stack;
        }

        public static void FirstInit()
        {
            _queue.Enqueue(2);
            _queue.Enqueue(3);
            _queue.Enqueue(5);
            _queue.Enqueue(8);
            _queue.Enqueue(13);
            Console.WriteLine("\tInit -> " + _queue);
        }

        public static void SecondInit()
        {
            _queue.Enqueue(21);
            _queue.Enqueue(8);
            _queue.Enqueue(5);
            _queue.Enqueue(13);

            Console.WriteLine("\tInit -> " + _queue);
        }

        public override void TakeExample()
        {
            Console.WriteLine("\tDequeue -> " + _queue.Dequeue());
        }

        public override void GetFirstExample()
        {
            Console.WriteLine("\tPeek -> " + _queue.Peek());
        }

        public override void IsFullExample()
        {
            Console.WriteLine("\tIsFull -> " + _queue.IsFull);
        }

        public override void IsEmptyExample()
        {
            Console.WriteLine("\tIsEmpty -> " + _queue.IsEmpty);
        }

    }

    public class ArrayQueueExample : QueueExample
    {
        public ArrayQueueExample() : base(new ArrayQueue<int>(5))
        {
        }
    }

    public class VectorQueueExample : QueueExample
    {
        public VectorQueueExample() : base(new VectorQueue<int>())
        {
        }
    }

    public class ListQueueExample : QueueExample
    {
        public ListQueueExample() : base(new ListQueue<int>())
        {
        }
    }

}