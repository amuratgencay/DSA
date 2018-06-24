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
        private readonly Array<int> _array;

        public ArrayExample()
        {
            _array = new Array<int>(5);
        }
        public void FirstInit()
        {
            _array[0] = 2;
            _array[1] = 3;
            _array[2] = 5;
            _array[3] = 8;
            _array[4] = 13;
            Console.WriteLine("\tInit -> " + _array);
        }

        public void SecondInit()
        {
            _array[0] = 21;
            _array[1] = 8;
            _array[2] = 5;
            _array[3] = 13;

            Console.WriteLine("\tInit -> " + _array);
        }
        public void Run()
        {
            var example = new CountableExample<int>(_array, 5, 8, 13, 13, 1, 21, 2, FirstInit, SecondInit);
            example.Run();
        }

    }
}