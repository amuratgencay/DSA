using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DSA.BLL.DataStructures;
using DSA.BLL.DataStructures.LinkedList.CircularLinkedList;
using DSA.BLL.DataStructures.Search;
using DSA.BLL.DataStructures.Sort;

namespace DSA.ConsoleApp.DataStructures.LinkedList.CircularLinkedList
{
    public static class CircularLinkedListExample
    {
        public static void Run()
        {
            var list = new CircularLinkedList<int>();

            Console.WriteLine("<Circular Linked List>");
            Console.WriteLine();
            list.Add(2);
            list.Add(3);
            list.Add(5);
            list.Add(8);
            list.Add(13);
            Console.WriteLine("\tAdd -> " + list);
            Console.WriteLine();
            list.Insert(2, 7);
            Console.WriteLine("\tInsert -> (2,7): " + list);
            Console.WriteLine();
            list.Remove(7);
            Console.WriteLine("\tRemove -> (7): " + list);
            Console.WriteLine();
            list.RemoveAt(2);
            Console.WriteLine("\tRemoveAt -> (2) " + list);
            Console.WriteLine();
            Console.WriteLine("\tContains -> (8): " + list.Contains(8));
            Console.WriteLine();
            Console.WriteLine("\tIndexOf -> (13): " + list.IndexOf(13));
            Console.WriteLine();
            Console.WriteLine("\tLastIndexOf -> (13): " + list.LastIndexOf(13));
            Console.WriteLine();
            list.Reverse();
            Console.WriteLine("\tReverse -> " + list);
            Console.WriteLine();
            Console.WriteLine("\tCount -> " + list.Count);
            Console.WriteLine();
            list[1] = 21;
            Console.WriteLine("\tSet[1] = 21 -> " + list);
            Console.WriteLine();
            Console.WriteLine("\tGet[2] -> " + list[2]);
            Console.WriteLine();
            list.Clear();
            Console.WriteLine("\tClear -> " + list);
            Console.WriteLine();
            list.Add(21);
            list.Add(8);
            list.Add(5);
            list.Add(13);
            Console.WriteLine("\tAdd -> " + list);
            Console.WriteLine();
            var searchType = typeof(ISearch<>);
            var search = new List<Type>(Assembly.GetAssembly(searchType).GetTypes())
                .Where(x => x.GetInterfaces().Any(y => y.Name == searchType.Name)).ToList();
            foreach (var type in search)
            {
                var genericType = type.MakeGenericType(typeof(int));
                var item = (ISearch<int>) Activator.CreateInstance(genericType);
                Console.WriteLine("\t" + genericType.GetCleanTypeName() + " -> " + item.Search(list, 5));
                Console.WriteLine();
            }

            var sortType = typeof(ISort<>);
            var sort = new List<Type>(Assembly.GetAssembly(sortType).GetTypes())
                .Where(x => x.GetInterfaces().Any(y => y.Name == sortType.Name)).ToList();
            foreach (var type in sort)
            {
                var genericType = type.MakeGenericType(typeof(int));
                var item = (ISort<int>) Activator.CreateInstance(genericType);
                Console.WriteLine("\t" + genericType.GetCleanTypeName() + " -> " + item.Sort(list));
                Console.WriteLine();
                Console.WriteLine("\tOriginal -> " + list);
                Console.WriteLine();
            }

            Console.WriteLine("</Circular Linked List>");
            Console.WriteLine();
        }
    }
}