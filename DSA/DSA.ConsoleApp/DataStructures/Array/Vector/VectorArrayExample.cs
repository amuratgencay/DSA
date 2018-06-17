﻿using System;
using DSA.BLL.DataStructures.Array;
using DSA.Entity.DataStructures;

namespace DSA.ConsoleApp.DataStructures.Array.Vector
{
    public static class VectorArrayExample
    {
        public static void Run()
        {
            IExpandedCluster<int> cluster = new Vector<int>(5);


            Console.WriteLine("<Vector Array>");
            Console.WriteLine();
            cluster.Add(2);
            cluster.Add(3);
            cluster.Add(5);
            cluster.Add(8);
            cluster.Add(13);
            Console.WriteLine("\tAdd -> " + cluster);
            Console.WriteLine();
            cluster.Insert(2, 7);
            Console.WriteLine("\tInsert -> (2,7): " + cluster);
            Console.WriteLine();
            cluster.Remove(7);
            Console.WriteLine("\tRemove -> (7): " + cluster);
            Console.WriteLine();
            cluster.RemoveAt(3);
            Console.WriteLine("\tRemoveAt -> (3) " + cluster);
            Console.WriteLine();
            Console.WriteLine("\tContains -> (8): " + cluster.Contains(8));
            Console.WriteLine();
            Console.WriteLine("\tIndexOf -> (13): " + cluster.IndexOf(13));
            Console.WriteLine();
            cluster.Reverse();
            Console.WriteLine("\tReverse -> " + cluster);
            Console.WriteLine();
            Console.WriteLine("\tCount -> " + cluster.Count());
            Console.WriteLine();
            cluster[1] = 21;
            Console.WriteLine("\tSet[1] = 21 -> " + cluster);
            Console.WriteLine();
            Console.WriteLine("\tGet[2] -> " + cluster[2]);
            Console.WriteLine();
            cluster.Clear();
            Console.WriteLine("\tClear -> " + cluster);
            Console.WriteLine();
            cluster.Add(5);
            cluster.Add(8);
            cluster.Add(13);
            Console.WriteLine("\tAdd -> " + cluster);
            Console.WriteLine();
            Console.WriteLine("</Vector Array>");
            Console.WriteLine();
        }
    }
}