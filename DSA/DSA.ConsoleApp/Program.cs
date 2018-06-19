using System;
using DSA.ConsoleApp.DataStructures.Array.Sequence;
using DSA.ConsoleApp.DataStructures.Array.Vector;
using DSA.ConsoleApp.DataStructures.LinkedList.CircularLinkedList;
using DSA.ConsoleApp.DataStructures.LinkedList.DoublyLinkedList;
using DSA.ConsoleApp.DataStructures.LinkedList.SinglyLinkedList;
using DSA.ConsoleApp.DataStructures.Queue;
using DSA.ConsoleApp.DataStructures.Stack;

namespace DSA.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                            Data Structures and Algorithms                          ║");
                Console.WriteLine("╠════════════════╦════════════════╦════════════════╦════════════════╦════════════════╣");
                Console.WriteLine("║    1. Array    ║ 2. Linked List ║   3. Stack     ║   4. Queue     ║    X. Exit     ║");
                Console.WriteLine("╚════════════════╩════════════════╩════════════════╩════════════════╩════════════════╝");
                var choice = char.ToLower(Console.ReadKey().KeyChar);
                Console.Clear();
                var done = false;
                switch (choice)
                {
                    case '1':
                        while (!done)
                        {
                            Console.WriteLine("╔═════════════════════════════════════════════════════════════════╗");
                            Console.WriteLine("║                              Array                              ║");
                            Console.WriteLine("╠═════════════════════╦═════════════════════╦═════════════════════╣");
                            Console.WriteLine("║ 1. Sequential Array ║     2. Vector       ║       B. Back       ║");
                            Console.WriteLine("╚═════════════════════╩═════════════════════╩═════════════════════╝");
                            choice = char.ToLower(Console.ReadKey().KeyChar);
                            Console.Clear();
                            switch (choice)
                            {
                                case '1':
                                    ArrayExample.Run();
                                    break;
                                case '2':
                                    VectorArrayExample.Run();
                                    break;
                                case 'b':
                                    done = true;
                                    break;
                                default:
                                    Console.WriteLine("Choice range (1-2) or B for previous menu. ");
                                    break;
                            }
                        }

                        break;
                    case '2':
                        while (!done)
                        {
                            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                            Console.WriteLine("║                                            Linked List                                                ║");
                            Console.WriteLine("╠═════════════════════════╦═════════════════════════╦═════════════════════════╦═════════════════════════╣");
                            Console.WriteLine("║ 1. Singly Linked List   ║ 2. Doubly Linked List   ║ 3. Circular Linked List ║        B. Back          ║");
                            Console.WriteLine("╚═════════════════════════╩═════════════════════════╩═════════════════════════╩═════════════════════════╝");
                            choice = char.ToLower(Console.ReadKey().KeyChar);
                            Console.Clear();
                            switch (choice)
                            {
                                case '1':
                                    SinglyLinkedListExample.Run();
                                    break;
                                case '2':
                                    DoublyLinkedListExample.Run();
                                    break;
                                case '3':
                                    CircularLinkedListExample.Run();
                                    break;
                                case 'b':
                                    done = true;
                                    break;
                                default:
                                    Console.WriteLine("Choice range (1-3) or B for previous menu. ");
                                    break;
                            }
                        }

                        break;
                    case '3':
                        while (!done)
                        {
                            Console.WriteLine("╔════════════════════════════════════════════════════════════════════════╗");
                            Console.WriteLine("║                                  Stack                                 ║");
                            Console.WriteLine("╠══════════════════╦═════════════════╦════════════════╦══════════════════╣");
                            Console.WriteLine("║ 1. Array Stack   ║ 2. Vector Stack ║ 3. List Stack  ║      B. Back     ║");
                            Console.WriteLine("╚══════════════════╩═════════════════╩════════════════╩══════════════════╝");
                            choice = char.ToLower(Console.ReadKey().KeyChar);
                            Console.Clear();
                            switch (choice)
                            {
                                case '1':
                                    ArrayStackExample.Run();
                                    break;
                                case '2':
                                    VectorStackExample.Run();
                                    break;
                                case '3':
                                    ListStackExample.Run();
                                    break;
                                case 'b':
                                    done = true;
                                    break;
                                default:
                                    Console.WriteLine("Choice range (1-3) or B for previous menu. ");
                                    break;
                            }
                        }

                        break;
                    case '4':
                        while (!done)
                        {
                            Console.WriteLine("╔════════════════════════════════════════════════════════════════════════╗");
                            Console.WriteLine("║                                  Queue                                 ║");
                            Console.WriteLine("╠══════════════════╦═════════════════╦════════════════╦══════════════════╣");
                            Console.WriteLine("║ 1. Array Queue   ║ 2. Vector Queue ║ 3. List Queue  ║      B. Back     ║");
                            Console.WriteLine("╚══════════════════╩═════════════════╩════════════════╩══════════════════╝");
                            choice = char.ToLower(Console.ReadKey().KeyChar);
                            Console.Clear();
                            switch (choice)
                            {
                                case '1':
                                    ArrayQueueExample.Run();
                                    break;
                                case '2':
                                    VectorQueueExample.Run();
                                    break;
                                case '3':
                                    ListQueueExample.Run();
                                    break;
                                case 'b':
                                    done = true;
                                    break;
                                default:
                                    Console.WriteLine("Choice range (1-3) or B for previous menu. ");
                                    break;
                            }
                        }

                        break;
                    case 'x':
                        return;
                    default:
                        Console.WriteLine("Choice range (1-4) or X for exit. ");
                        break;
                }
            }
        }
    }
}