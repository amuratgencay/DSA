using System;
using DSA.ConsoleApp.DataStructures.Array.Sequence;
using DSA.ConsoleApp.DataStructures.Array.Vector;
using DSA.ConsoleApp.DataStructures.LinkedList.CircularLinkedList;
using DSA.ConsoleApp.DataStructures.LinkedList.DoublyLinkedList;
using DSA.ConsoleApp.DataStructures.LinkedList.SinglyLinkedList;
using DSA.ConsoleApp.DataStructures.Stack;

namespace DSA.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                                    Data Structures and Algorithms                                     ║");
                Console.WriteLine("╠═════════════════════════╦═════════════════════════╦═════════════════════════╦═════════════════════════╣");
                Console.WriteLine("║       1. Array          ║       2. Vector         ║ 3. Singly Linked List   ║   4. Doubly Linked List ║");
                Console.WriteLine("╠═════════════════════════╬═════════════════════════╬═════════════════════════╬═════════════════════════╣");
                Console.WriteLine("║ 5. Circular Linked List ║    6. Fixed Stack       ║  7. Expanded Stack      ║     8. Fixed Queue      ║");
                Console.WriteLine("╠═════════════════════════╬═════════════════════════╬═════════════════════════╬═════════════════════════╣");
                Console.WriteLine("║   9. Expanded Queue     ║                         ║                         ║        X. Exit          ║");
                Console.WriteLine("╚═════════════════════════╩═════════════════════════╩═════════════════════════╩═════════════════════════╝");
                var choice = char.ToLower(Console.ReadKey().KeyChar);
                Console.Clear();
                switch (choice)
                {
                    case '1':
                        ArrayExample.Run();
                        break;
                    case '2':
                        VectorArrayExample.Run();
                        break;
                    case '3':
                        SinglyLinkedListExample.Run();
                        break;
                    case '4':
                        DoublyLinkedListExample.Run();
                        break;
                    case '5':
                        CircularLinkedListExample.Run();
                        break;
                    case '6':
                        FixedStackExample.Run();
                        break;
                    case '7':
                        ExpandedStackExample.Run();
                        break;
                    case '8':
                        FixedQueueExample.Run();
                        break;
                    case '9':
                        ExpandedQueueExample.Run();
                        break;
                    case 'x':
                        return;
                    default:
                        Console.WriteLine("Choice range (1-7) or X for exit. ");
                        break;
                }
            }
        }
    }
}