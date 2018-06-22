using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.BLL.DataStructures.Sort
{
    public interface ISort<T>
    {
        ICountable<T> Sort(ICountable<T> array);
    }
    public class BubbleSort<T> : ISort<T> where T : IComparable
    {
        public ICountable<T> Sort(ICountable<T> array)
        {
            for (int i = 0; i < array.Count - 1; i++)
            {
                for (int j = 0; j < array.Count - 1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        var tmp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tmp;
                    }

                }
            }
            return array;
        }
    }

    public class InsertionSort<T> : ISort<T> where T : IComparable
    {
        public ICountable<T> Sort(ICountable<T> array)
        {
            for (int i = 0; i < array.Count - 1; i++)
            {
                for (int j = 0; j < array.Count - 1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        var tmp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tmp;
                    }

                }
            }
            return array;
        }
    }
}
