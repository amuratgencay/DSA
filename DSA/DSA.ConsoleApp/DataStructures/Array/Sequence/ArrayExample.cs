using System;
using DSA.BLL.DataStructures.Array;
using DSA.BLL.DataStructures.Search;

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
            array[0] = 5;
            array[1] = 8;
            array[2] = 13;
            Console.WriteLine("\tAdd -> " + array);
            Console.WriteLine();
            Console.WriteLine("\tLinear Search -> " + new LinearSearch<int>().Search(array, 5));
            Console.WriteLine();
            Console.WriteLine("\tBinary Search -> " + new BinarySearch<int>().Search(array, 5));
            Console.WriteLine();
            Console.WriteLine("\tInterpolation Search -> " + new InterpolationSearch().Search(array, 5));
            Console.WriteLine();
            Console.WriteLine("</Sequential Array>");
            Console.WriteLine();
        }
    }
}