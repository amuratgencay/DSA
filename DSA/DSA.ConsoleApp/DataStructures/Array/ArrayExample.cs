using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSA.BLL.DataStructures;
using DSA.BLL.DataStructures.Array;
using DSA.ConsoleApp.DataStructures.Example;

namespace DSA.ConsoleApp.DataStructures.Array
{
    public class ArrayExample : CountableExample<int>
    {
        private static ICountable<int> _array;

        public ArrayExample(ICountable<int> array) : base(array,  5, 8, 13, 13, 1, 21, 2, FirstInit, SecondInit)
        {
            _array = array;
        }

        public static void FirstInit()
        {
            _array[0] = 2;
            _array[1] = 3;
            _array[2] = 5;
            _array[3] = 8;
            _array[4] = 13;
            Console.WriteLine("\tInit -> " + _array);
        }

        public static void SecondInit()
        {
            _array[0] = 21;
            _array[1] = 8;
            _array[2] = 5;
            _array[3] = 13;

            Console.WriteLine("\tInit -> " + _array);
        }
    }

    public class SequenceArrayExample : ArrayExample
    {
        public SequenceArrayExample() : base(new Array<int>(5))
        {
        }
    }

    public class VectorArrayExample : ArrayExample
    {
        public VectorArrayExample() : base(new Vector<int>())
        {
        }
    }
}
