using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DSA.BLL.DataStructures;
using DSA.BLL.DataStructures.LinkedList.SinglyLinkedList;
using DSA.BLL.DataStructures.Search;
using DSA.BLL.DataStructures.Sort;

namespace DSA.ConsoleApp.DataStructures.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedListExample
    {
        private readonly SinglyLinkedList<int> _list;

        public SinglyLinkedListExample()
        {
            _list = new SinglyLinkedList<int>();
        }
        public void FirstInit()
        {
            _list.Add(2);
            _list.Add(3);
            _list.Add(5);
            _list.Add(8);
            _list.Add(13);
            Console.WriteLine("\tInit -> " + _list);
        }

        public void SecondInit()
        {
            _list.Add(21);
            _list.Add(8);
            _list.Add(5);
            _list.Add(13);

            Console.WriteLine("\tInit -> " + _list);
        }
        public void Run()
        {
            var example = new CountableExample<int>(_list, 5, 8, 13, 13, 1, 21, 2, FirstInit, SecondInit);
            example.Run();
        }       
    }
}