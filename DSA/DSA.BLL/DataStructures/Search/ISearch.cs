using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.BLL.DataStructures.Search
{
    public interface ISearch<T>
    {
        T Search(ICountable<T> array, T item);
    }
}
