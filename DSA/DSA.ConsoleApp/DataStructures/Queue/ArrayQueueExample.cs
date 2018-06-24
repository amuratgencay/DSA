using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DSA.BLL.DataStructures;
using DSA.BLL.DataStructures.Queue;
using DSA.BLL.DataStructures.Search;
using DSA.BLL.DataStructures.Sort;

namespace DSA.ConsoleApp.DataStructures.Queue
{
    public class ArrayQueueExample
    {
        public static void Run()
        {
            var queue = new ArrayQueue<int>(5);

            Console.WriteLine("<Array Queue>");
            Console.WriteLine();
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(5);
            queue.Enqueue(8);
            queue.Enqueue(13);
            Console.WriteLine("\tEnqueue -> " + queue);
            Console.WriteLine();
            Console.WriteLine("\tContains -> (8): " + queue.Contains(8));
            Console.WriteLine();
            Console.WriteLine("\tIndexOf -> (13): " + queue.IndexOf(13));
            Console.WriteLine();
            Console.WriteLine("\tLastIndexOf -> (13): " + queue.LastIndexOf(13));
            Console.WriteLine();
            Console.WriteLine("\tPeek -> " + queue.Peek());
            Console.WriteLine();
            Console.WriteLine("\tIsFull -> " + queue.IsFull);
            Console.WriteLine();
            Console.WriteLine("\tDequeue -> " + queue.Dequeue());
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
            queue.Enqueue(21);
            queue.Enqueue(8);
            queue.Enqueue(5);
            queue.Enqueue(13);
            Console.WriteLine("\tEnqueue -> " + queue);
            Console.WriteLine();
            var searchType = typeof(ISearch<>);
            var search = new List<Type>(Assembly.GetAssembly(searchType).GetTypes())
                .Where(x => x.GetInterfaces().Any(y => y.Name == searchType.Name)).ToList();
            foreach (var type in search)
            {
                var genericType = type.MakeGenericType(typeof(int));
                var item = (ISearch<int>) Activator.CreateInstance(genericType);
                Console.WriteLine("\t" + genericType.GetCleanTypeName() + " -> " + item.Search(queue, 5));
                Console.WriteLine();
            }

            var sortType = typeof(ISort<>);
            var sort = new List<Type>(Assembly.GetAssembly(sortType).GetTypes())
                .Where(x => x.GetInterfaces().Any(y => y.Name == sortType.Name)).ToList();
            foreach (var type in sort)
            {
                var genericType = type.MakeGenericType(typeof(int));
                var item = (ISort<int>) Activator.CreateInstance(genericType);
                Console.WriteLine("\t" + genericType.GetCleanTypeName() + " -> " + item.Sort(queue));
                Console.WriteLine();
                Console.WriteLine("\tOriginal -> " + queue);
                Console.WriteLine();
            }

            Console.WriteLine("</Array Queue>");
            Console.WriteLine();
        }
    }
}