using System;
using DSA.BLL.DataStructures;
using DSA.BLL.DataStructures.Array;

namespace DSA.ConsoleApp.DataStructures.Array.Sequence
{
    public class ArrayExample
    {
        public static void Run()
        {
            ICountable<int> countable = new Sequence<int>(5);

            Console.WriteLine("<Sequence Array>");
            Console.WriteLine();
            Console.WriteLine("\tCreate -> " + countable);
            Console.WriteLine();
            countable[0] = 2;
            countable[1] = 3;
            countable[2] = 5;
            countable[3] = 8;
            countable[4] = 13;
            Console.WriteLine("\tAdd -> " + countable);
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
            countable[0] = 5;
            countable[1] = 8;
            countable[2] = 13;
            Console.WriteLine("\tAdd -> " + countable);
            Console.WriteLine();
            Console.WriteLine("</Sequence Array>");
            Console.WriteLine();
        }
    }
}