using System;
using DSA.BLL.DataStructures;
using DSA.BLL.DataStructures.Array;

namespace DSA.ConsoleApp.DataStructures.Array.Sequence
{
    public class ArrayExample
    {
        public static void Run()
        {
            ICluster<int> cluster = new Sequence<int>(5);

            Console.WriteLine("<Sequence Array>");
            Console.WriteLine();
            Console.WriteLine("\tCreate -> " + cluster);
            Console.WriteLine();
            cluster[0] = 2;
            cluster[1] = 3;
            cluster[2] = 5;
            cluster[3] = 8;
            cluster[4] = 13;
            Console.WriteLine("\tAdd -> " + cluster);
            Console.WriteLine();
            Console.WriteLine("\tContains -> (8): " + cluster.Contains(8));
            Console.WriteLine();
            Console.WriteLine("\tIndexOf -> (13): " + cluster.IndexOf(13));
            Console.WriteLine();
            cluster.Reverse();
            Console.WriteLine("\tReverse -> " + cluster);
            Console.WriteLine();
            Console.WriteLine("\tCount -> " + cluster.Count);
            Console.WriteLine();
            cluster[1] = 21;
            Console.WriteLine("\tSet[1] = 21 -> " + cluster);
            Console.WriteLine();
            Console.WriteLine("\tGet[2] -> " + cluster[2]);
            Console.WriteLine();
            cluster.Clear();
            Console.WriteLine("\tClear -> " + cluster);
            Console.WriteLine();
            cluster[0] = 5;
            cluster[1] = 8;
            cluster[2] = 13;
            Console.WriteLine("\tAdd -> " + cluster);
            Console.WriteLine();
            Console.WriteLine("</Sequence Array>");
            Console.WriteLine();
        }
    }
}