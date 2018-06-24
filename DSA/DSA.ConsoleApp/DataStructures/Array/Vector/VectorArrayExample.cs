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
    public class VectorArrayExample
    {

        private readonly Vector<int> _vector;

        public VectorArrayExample()
        {
            _vector = new Vector<int>(8);
        }
        public void FirstInit()
        {
            _vector.Add(2);
            _vector.Add(3);
            _vector.Add(5);
            _vector.Add(8);
            _vector.Add(13);
            Console.WriteLine("\tInit -> " + _vector);
        }

        public void SecondInit()
        {
            _vector.Add(21);
            _vector.Add(8);
            _vector.Add(5);
            _vector.Add(13);

            Console.WriteLine("\tInit -> " + _vector);
        }
        public void Run()
        {
            var example = new CountableExample<int>(_vector, 5, 8, 13, 13, 1, 21, 2, FirstInit, SecondInit);
            
            example.Run();
        }
    }
}