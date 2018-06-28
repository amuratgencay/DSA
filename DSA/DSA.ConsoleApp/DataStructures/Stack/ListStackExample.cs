using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DSA.BLL.DataStructures;
using DSA.BLL.DataStructures.Search;
using DSA.BLL.DataStructures.Sort;
using DSA.BLL.DataStructures.Stack;

namespace DSA.ConsoleApp.DataStructures.Stack
{
    public class ListStackExample : StackExample
    {
        public ListStackExample() : base(new ListStack<int>(5))
        {

        }
    }
}