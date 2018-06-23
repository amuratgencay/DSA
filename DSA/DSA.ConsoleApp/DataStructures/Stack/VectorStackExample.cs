using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DSA.BLL.DataStructures;
using DSA.BLL.DataStructures.Search;
using DSA.BLL.DataStructures.Sort;
using DSA.BLL.DataStructures.Stack;

namespace DSA.ConsoleApp.DataStructures.Stack
{
    public class VectorStackExample
    {
        public static void Run()
        {
            var stack = new VectorStack<int>();

            Console.WriteLine("<Vector Stack>");
            Console.WriteLine();
            stack.Push(2);
            stack.Push(3);
            stack.Push(5);
            stack.Push(8);
            stack.Push(13);
            Console.WriteLine("\tPush -> " + stack);
            Console.WriteLine();
            Console.WriteLine("\tContains -> (8): " + stack.Contains(8));
            Console.WriteLine();
            Console.WriteLine("\tIndexOf -> (13): " + stack.IndexOf(13));
            Console.WriteLine();
            Console.WriteLine("\tLastIndexOf -> (13): " + stack.LastIndexOf(13));
            Console.WriteLine();
            Console.WriteLine("\tPeek -> " + stack.Peek());
            Console.WriteLine();
            Console.WriteLine("\tIsFull -> " + stack.IsFull);
            Console.WriteLine();
            Console.WriteLine("\tPop -> " + stack.Pop());
            Console.WriteLine();
            Console.WriteLine("\tDisplay -> " + stack);
            Console.WriteLine();
            stack.Reverse();
            Console.WriteLine("\tReverse -> " + stack);
            Console.WriteLine();
            Console.WriteLine("\tCount -> " + stack.Count);
            Console.WriteLine();
            stack[1] = 21;
            Console.WriteLine("\tSet[1] = 21 -> " + stack);
            Console.WriteLine();
            Console.WriteLine("\tGet[2] -> " + stack[2]);
            Console.WriteLine();
            stack.Clear();
            Console.WriteLine("\tClear -> " + stack);
            Console.WriteLine();
            Console.WriteLine("\tIsEmpty -> " + stack.IsEmpty);
            Console.WriteLine();
            stack.Push(21);
            stack.Push(8);
            stack.Push(5);
            stack.Push(13);
            Console.WriteLine("\tPush -> " + stack);
            Console.WriteLine();
            var searchType = typeof(ISearch<>);
            var search = new List<Type>(Assembly.GetAssembly(searchType).GetTypes())
                .Where(x => x.GetInterfaces().Any(y => y.Name == searchType.Name)).ToList();
            foreach (var type in search)
            {
                var genericType = type.MakeGenericType(typeof(int));
                var item = (ISearch<int>) Activator.CreateInstance(genericType);
                Console.WriteLine("\t" + genericType.GetCleanTypeName() + " -> " + item.Search(stack, 5));
                Console.WriteLine();
            }

            var sortType = typeof(ISort<>);
            var sort = new List<Type>(Assembly.GetAssembly(sortType).GetTypes())
                .Where(x => x.GetInterfaces().Any(y => y.Name == sortType.Name)).ToList();
            foreach (var type in sort)
            {
                var genericType = type.MakeGenericType(typeof(int));
                var item = (ISort<int>) Activator.CreateInstance(genericType);
                Console.WriteLine("\t" + genericType.GetCleanTypeName() + " -> " + item.Sort(stack));
                Console.WriteLine();
                Console.WriteLine("\tOriginal -> " + stack);
                Console.WriteLine();
            }

            Console.WriteLine("</Vector Stack>");
            Console.WriteLine();
        }
    }
}