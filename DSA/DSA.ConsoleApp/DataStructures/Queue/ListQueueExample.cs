using System;
using DSA.BLL.DataStructures.Queue;
using DSA.BLL.DataStructures.Search;

namespace DSA.ConsoleApp.DataStructures.Queue
{
    public class ListQueueExample
    {
        public static void Run()
        {
            var queue = new ListQueue<int>();            
            Console.WriteLine("<List Queue>");
            Console.WriteLine();
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(5);
            queue.Enqueue(8);
            queue.Enqueue(13);
            Console.WriteLine("\tPush -> " + queue);
            Console.WriteLine();
            Console.WriteLine("\tContains -> (8): " + queue.Contains(8));
            Console.WriteLine();
            Console.WriteLine("\tIndexOf -> (13): " + queue.IndexOf(13));
            Console.WriteLine();
            Console.WriteLine("\tPeek -> " + queue.Peek());
            Console.WriteLine();
            Console.WriteLine("\tIsFull -> " + queue.IsFull);
            Console.WriteLine();
            Console.WriteLine("\tPop -> " + queue.Dequeue());
            Console.WriteLine();
            Console.WriteLine("\tDisplay -> " + queue);
            Console.WriteLine();
            queue.Reverse();
            Console.WriteLine("\tReverse -> " + queue);
            Console.WriteLine();
            Console.WriteLine("\tCount -> " + queue.Count);
            Console.WriteLine();
            queue[1] = 21;
            Console.WriteLine("\tSet[1] = 21 -> " + queue);
            Console.WriteLine();
            Console.WriteLine("\tGet[2] -> " + queue[2]);
            Console.WriteLine();
            queue.Clear();
            Console.WriteLine("\tClear -> " + queue);
            Console.WriteLine();
            Console.WriteLine("\tIsEmpty -> " + queue.IsEmpty);
            Console.WriteLine();
            queue.Enqueue(5);
            queue.Enqueue(8);
            queue.Enqueue(13);
            Console.WriteLine("\tPush -> " + queue);
            Console.WriteLine();
            Console.WriteLine("\tLinear Search -> " + new LinearSearch<int>().Search(queue, 5));
            Console.WriteLine();
            Console.WriteLine("\tBinary Search -> " + new BinarySearch<int>().Search(queue, 5));
            Console.WriteLine();
            Console.WriteLine("\tInterpolation Search -> " + new InterpolationSearch().Search(queue, 5));
            Console.WriteLine();
            Console.WriteLine("</List Queue>");
            Console.WriteLine();
        }
    }
}