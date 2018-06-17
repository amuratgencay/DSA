using System;
using DSA.ConsoleApp.DataStructures.LinkedList.CircularLinkedList;
using DSA.ConsoleApp.DataStructures.LinkedList.DoublyLinkedList;
using DSA.ConsoleApp.DataStructures.LinkedList.SinglyLinkedList;

namespace DSA.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("*******************Linked List*******************\n");
            SinglyLinkedListExample.Run();
            DoublyLinkedListExample.Run();
            CircularLinkedListExample.Run();
        }
    }
}