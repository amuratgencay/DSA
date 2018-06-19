using System;
using DSA.BLL.DataStructures.Stack;

namespace DSA.ConsoleApp.DataStructures.Stack
{
    public class ListStackExample
    {
        public static void Run()
        {
            var cluster = new ListStack<int>();

            Console.WriteLine("<List Stack>");
            Console.WriteLine();
            cluster.Push(2);
            cluster.Push(3);
            cluster.Push(5);
            cluster.Push(8);
            cluster.Push(13);
            Console.WriteLine("\tPush -> " + cluster);
            Console.WriteLine();
            Console.WriteLine("\tContains -> (8): " + cluster.Contains(8));
            Console.WriteLine();
            Console.WriteLine("\tIndexOf -> (13): " + cluster.IndexOf(13));
            Console.WriteLine();
            Console.WriteLine("\tPeek -> " + cluster.Peek());
            Console.WriteLine();
            Console.WriteLine("\tIsFull -> " + cluster.IsFull);
            Console.WriteLine();
            Console.WriteLine("\tPop -> " + cluster.Pop());
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
            cluster.Push(5);
            cluster.Push(8);
            cluster.Push(13);
            Console.WriteLine("\tPush -> " + cluster);
            Console.WriteLine();
            Console.WriteLine("</List Stack>");
            Console.WriteLine();
        }
    }
}