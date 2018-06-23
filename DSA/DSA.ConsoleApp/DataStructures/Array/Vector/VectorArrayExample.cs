using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DSA.BLL.DataStructures;
using DSA.BLL.DataStructures.Array;
using DSA.BLL.DataStructures.Search;
using DSA.BLL.DataStructures.Sort;

namespace DSA.ConsoleApp.DataStructures.Array.Vector
{
    public static class VectorArrayExample
    {
        public static void Run()
        {
            var vector = new Vector<int>(8);

            Console.WriteLine("<Vector Arr>");
            Console.WriteLine();
            vector.Add(2);
            vector.Add(3);
            vector.Add(5);
            vector.Add(8);
            vector.Add(13);
            Console.WriteLine("\tAdd -> " + vector);
            Console.WriteLine();
            vector.Insert(2, 7);
            Console.WriteLine("\tInsert -> (2,7): " + vector);
            Console.WriteLine();
            vector.Remove(7);
            Console.WriteLine("\tRemove -> (7): " + vector);
            Console.WriteLine();
            vector.RemoveAt(3);
            Console.WriteLine("\tRemoveAt -> (3) " + vector);
            Console.WriteLine();
            Console.WriteLine("\tContains -> (8): " + vector.Contains(8));
            Console.WriteLine();
            Console.WriteLine("\tIndexOf -> (13): " + vector.IndexOf(13));
            Console.WriteLine();
            Console.WriteLine("\tLastIndexOf -> (13): " + vector.LastIndexOf(13));
            Console.WriteLine();
            vector.Reverse();
            Console.WriteLine("\tReverse -> " + vector);
            Console.WriteLine();
            Console.WriteLine("\tCount -> " + vector.Count);
            Console.WriteLine();
            vector[1] = 21;
            Console.WriteLine("\tSet[1] = 21 -> " + vector);
            Console.WriteLine();
            Console.WriteLine("\tGet[2] -> " + vector[2]);
            Console.WriteLine();
            vector.Clear();
            Console.WriteLine("\tClear -> " + vector);
            Console.WriteLine();
            vector.Add(21);
            vector.Add(8);
            vector.Add(5);
            vector.Add(13);
            Console.WriteLine("\tAdd -> " + vector);
            Console.WriteLine();

            var searchType = typeof(ISearch<>);
            var search = new List<Type>(Assembly.GetAssembly(searchType).GetTypes())
                .Where(x => x.GetInterfaces().Any(y => y.Name == searchType.Name)).ToList();
            foreach (var type in search)
            {
                var genericType = type.MakeGenericType(typeof(int));
                var item = (ISearch<int>) Activator.CreateInstance(genericType);
                Console.WriteLine("\t" + genericType.GetCleanTypeName() + " -> " + item.Search(vector, 5));
                Console.WriteLine();
            }

            var sortType = typeof(ISort<>);
            var sort = new List<Type>(Assembly.GetAssembly(sortType).GetTypes())
                .Where(x => x.GetInterfaces().Any(y => y.Name == sortType.Name)).ToList();
            foreach (var type in sort)
            {
                var genericType = type.MakeGenericType(typeof(int));
                var item = (ISort<int>) Activator.CreateInstance(genericType);
                Console.WriteLine("\t" + genericType.GetCleanTypeName() + " -> " + item.Sort(vector));
                Console.WriteLine();
                Console.WriteLine("\tOriginal -> " + vector);
                Console.WriteLine();
            }

            Console.WriteLine("</Vector Arr>");
            Console.WriteLine();
        }
    }
}