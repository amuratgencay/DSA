using System;
using DSA.BLL.DataStructures.LinkedList;
using DSA.BLL.DataStructures.LinkedList.CircularLinkedList;
using DSA.BLL.DataStructures.LinkedList.DoublyLinkedList;
using DSA.BLL.DataStructures.LinkedList.SinglyLinkedList;
using DSA.ConsoleApp.DataStructures.Example;

namespace DSA.ConsoleApp.DataStructures.LinkedList
{
    public class LinkedListExample : ExtendedCountableExample<int>
    {
        private static LinkedList<int> _list;

        public LinkedListExample(LinkedList<int> list) : base(list, 5, 8, 13, 13, 1, 21, 2, FirstInit, SecondInit)
        {
            _list = list;
        }

        public static void FirstInit()
        {
            _list.Add(2);
            _list.Add(3);
            _list.Add(5);
            _list.Add(8);
            _list.Add(13);
            Console.WriteLine("\tInit -> " + _list);
        }

        public static void SecondInit()
        {
            _list.Add(21);
            _list.Add(8);
            _list.Add(5);
            _list.Add(13);

            Console.WriteLine("\tInit -> " + _list);
        }

        public override void TakeExample()
        {
            _list.RemoveAt(1);
            Console.WriteLine("\tRemoveAt(1) -> " + _list);
        }

        public override void GetFirstExample()
        {
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
        }

        public override void IsFullExample()
        {
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
        }

        public override void IsEmptyExample()
        {
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
        }
    }


    public class SinglyLinkedListExample : LinkedListExample
    {
        public SinglyLinkedListExample() : base(new SinglyLinkedList<int>())
        {
        }
    }

    public class DoublyLinkedListExample : LinkedListExample
    {
        public DoublyLinkedListExample() : base(new DoublyLinkedList<int>())
        {
        }
    }

    public class CircularLinkedListExample : LinkedListExample
    {
        public CircularLinkedListExample() : base(new CircularLinkedList<int>())
        {
        }
    }
}
