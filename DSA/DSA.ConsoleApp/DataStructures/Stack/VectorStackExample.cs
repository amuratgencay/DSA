using System;
using DSA.BLL.DataStructures.Search;
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
            stack.Push(5);
            stack.Push(8);
            stack.Push(13);
            Console.WriteLine("\tPush -> " + stack);
            Console.WriteLine();
            Console.WriteLine("\tLinear Search -> " + new LinearSearch<int>().Search(stack, 5));
            Console.WriteLine();
            Console.WriteLine("\tBinary Search -> " + new BinarySearch<int>().Search(stack, 5));
            Console.WriteLine();
            Console.WriteLine("\tInterpolation Search -> " + new InterpolationSearch().Search(stack, 5));
            Console.WriteLine();
            Console.WriteLine("</Vector Stack>");
            Console.WriteLine();
        }
    }
}