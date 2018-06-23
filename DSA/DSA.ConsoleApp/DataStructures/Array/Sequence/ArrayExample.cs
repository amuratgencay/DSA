using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DSA.BLL.DataStructures;
using DSA.BLL.DataStructures.Array;
using DSA.BLL.DataStructures.Search;
using DSA.BLL.DataStructures.Sort;

namespace DSA.ConsoleApp.DataStructures.Array.Sequence
{
    public class ArrayExample
    {
        public static void Run()
        {
            var array = new Array<int>(5);

            Console.WriteLine("<Sequential Array>");
            Console.WriteLine();
            Console.WriteLine("\tCreate -> " + array);
            Console.WriteLine();
            array[0] = 2;
            array[1] = 3;
            array[2] = 5;
            array[3] = 8;
            array[4] = 13;
            Console.WriteLine("\tAdd -> " + array);
            Console.WriteLine();
            Console.WriteLine("\tContains -> (8): " + array.Contains(8));
            Console.WriteLine();
            Console.WriteLine("\tIndexOf -> (13): " + array.IndexOf(13));
            Console.WriteLine();
            Console.WriteLine("\tLastIndexOf -> (13): " + array.LastIndexOf(13));
            Console.WriteLine();
            array.Reverse();
            Console.WriteLine("\tReverse -> " + array);
            Console.WriteLine();
            Console.WriteLine("\tCount -> " + array.Count);
            Console.WriteLine();
            array[1] = 21;
            Console.WriteLine("\tSet[1] = 21 -> " + array);
            Console.WriteLine();
            Console.WriteLine("\tGet[2] -> " + array[2]);
            Console.WriteLine();
            array.Clear();
            Console.WriteLine("\tClear -> " + array);
            Console.WriteLine();
            array[0] = 21;
            array[1] = 8;
            array[2] = 5;
            array[3] = 13;
            Console.WriteLine("\tAdd -> " + array);
            Console.WriteLine();

            var searchType = typeof(ISearch<>);
            var search = new List<Type>(Assembly.GetAssembly(searchType).GetTypes())
                .Where(x => x.GetInterfaces().Any(y => y.Name == searchType.Name)).ToList();
            foreach (var type in search)
            {
                var genericType = type.MakeGenericType(typeof(int));
                var item = (ISearch<int>) Activator.CreateInstance(genericType);
                Console.WriteLine("\t" + genericType.GetCleanTypeName() + " -> " + item.Search(array, 5));
                Console.WriteLine();
            }

            var sortType = typeof(ISort<>);
            var sort = new List<Type>(Assembly.GetAssembly(sortType).GetTypes())
                .Where(x => x.GetInterfaces().Any(y => y.Name == sortType.Name)).ToList();
            foreach (var type in sort)
            {
                var genericType = type.MakeGenericType(typeof(int));
                var item = (ISort<int>) Activator.CreateInstance(genericType);
                Console.WriteLine("\t" + genericType.GetCleanTypeName() + " -> " + item.Sort(array));
                Console.WriteLine();
                Console.WriteLine("\tOriginal -> " + array);
                Console.WriteLine();
            }

            Console.WriteLine("</Sequential Array>");
            Console.WriteLine();
        }
    }
}