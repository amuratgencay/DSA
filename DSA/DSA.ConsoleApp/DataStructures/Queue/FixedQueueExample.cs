using DSA.BLL.DataStructures.Queue;
using System;


namespace DSA.ConsoleApp.DataStructures.Stack
{
    public static class FixedQueueExample
    {
        public static void Run()
        {
            Queue<int> cluster = new FixedQueue<int>(5);

            Console.WriteLine("<Fixed Queue>");
            Console.WriteLine();
            cluster.Enqueue(2);
            cluster.Enqueue(3);
            cluster.Enqueue(5);
            cluster.Enqueue(8);
            cluster.Enqueue(13);
            Console.WriteLine("\tEnqueue -> " + cluster);
            Console.WriteLine();
            Console.WriteLine("\tContains -> (8): " + cluster.Contains(8));
            Console.WriteLine();
            Console.WriteLine("\tIndexOf -> (13): " + cluster.IndexOf(13));
            Console.WriteLine();
            Console.WriteLine("\tPeek -> " + cluster.Peek());
            Console.WriteLine();
            Console.WriteLine("\tIsFull -> " + cluster.IsFull);
            Console.WriteLine();
            Console.WriteLine("\tDequeue -> " + cluster.Dequeue());
            Console.WriteLine();
            Console.WriteLine("\tDisplay -> " + cluster);
            Console.WriteLine();
            cluster.Reverse();
            Console.WriteLine("\tReverse -> " + cluster);
            Console.WriteLine();
            Console.WriteLine("\tCount -> " + cluster.Count);
            Console.WriteLine();
            cluster[1] = 21;
            Console.WriteLine("\tSet[1] = 21 -> " + cluster);
            Console.WriteLine();
            Console.WriteLine("\tGet[2] -> " + cluster[2]);
            Console.WriteLine();
            cluster.Clear();
            Console.WriteLine("\tClear -> " + cluster);
            Console.WriteLine();
            Console.WriteLine("\tIsEmpty -> " + cluster.IsEmpty);
            Console.WriteLine();
            cluster.Enqueue(5);
            cluster.Enqueue(8);
            cluster.Enqueue(13);
            Console.WriteLine("\tEnqueue -> " + cluster);
            Console.WriteLine();
            Console.WriteLine("</Fixed Queue>");
            Console.WriteLine();
        }
    }
}