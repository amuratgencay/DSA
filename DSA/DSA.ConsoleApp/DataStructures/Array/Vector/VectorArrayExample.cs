using System;
using DSA.BLL.DataStructures.Array;
using DSA.BLL.DataStructures.Search;

namespace DSA.ConsoleApp.DataStructures.Array.Vector
{
    public static class VectorArrayExample
    {
        public static void Run()
        {
            var vector = new Vector<int>(8);

            Console.WriteLine("<Vector Array>");
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
            vector.Add(5);
            vector.Add(8);
            vector.Add(13);
            Console.WriteLine("\tAdd -> " + vector);
            Console.WriteLine();
            Console.WriteLine("\tLinear Search -> " + new LinearSearch<int>().Search(vector, 5));
            Console.WriteLine();
            Console.WriteLine("\tBinary Search -> " + new BinarySearch<int>().Search(vector, 5));
            Console.WriteLine();
            Console.WriteLine("\tInterpolation Search -> " + new InterpolationSearch().Search(vector, 5));
            Console.WriteLine();
            Console.WriteLine("</Vector Array>");
            Console.WriteLine();
        }
    }
}