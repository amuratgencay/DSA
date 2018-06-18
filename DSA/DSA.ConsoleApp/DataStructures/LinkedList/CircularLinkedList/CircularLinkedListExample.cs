using System;
using DSA.BLL.DataStructures.LinkedList.CircularLinkedList;

namespace DSA.ConsoleApp.DataStructures.LinkedList.CircularLinkedList
{
    public static class CircularLinkedListExample
    {
        public static void Run()
        {
            var countable = new CircularLinkedCountable<int>();

            Console.WriteLine("<Circular Linked List>");
            Console.WriteLine();
            countable.Add(2);
            countable.Add(3);
            countable.Add(5);
            countable.Add(8);
            countable.Add(13);
            Console.WriteLine("\tAdd -> " + countable);
            Console.WriteLine();
            countable.Insert(2, 7);
            Console.WriteLine("\tInsert -> (2,7): " + countable);
            Console.WriteLine();
            countable.Remove(7);
            Console.WriteLine("\tRemove -> (7): " + countable);
            Console.WriteLine();
            countable.RemoveAt(2);
            Console.WriteLine("\tRemoveAt -> (2) " + countable);
            Console.WriteLine();
            Console.WriteLine("\tContains -> (8): " + countable.Contains(8));
            Console.WriteLine();
            Console.WriteLine("\tIndexOf -> (13): " + countable.IndexOf(13));
            Console.WriteLine();
            countable.Reverse();
            Console.WriteLine("\tReverse -> " + countable);
            Console.WriteLine();
            Console.WriteLine("\tCount -> " + countable.Count);
            Console.WriteLine();
            countable[1] = 21;
            Console.WriteLine("\tSet[1] = 21 -> " + countable);
            Console.WriteLine();
            Console.WriteLine("\tGet[2] -> " + countable[2]);
            Console.WriteLine();
            countable.Clear();
            Console.WriteLine("\tClear -> " + countable);
            Console.WriteLine();
            countable.Add(5);
            countable.Add(8);
            countable.Add(13);
            Console.WriteLine("\tAdd -> " + countable);
            Console.WriteLine();
            Console.WriteLine("</Circular Linked List>");
            Console.WriteLine();
        }
    }
}