using System;
using System.IO;
using DSA.ConsoleApp.DataStructures.Array;
using DSA.ConsoleApp.DataStructures.Example;
using DSA.ConsoleApp.DataStructures.LinkedList;
using DSA.ConsoleApp.DataStructures.Queue;
using DSA.ConsoleApp.DataStructures.Recursion;
using DSA.ConsoleApp.DataStructures.Stack;

namespace DSA.ConsoleApp
{
    internal class Program
    {
        private static void Run(Type exampleType)
        {
            Example example = (Example)Activator.CreateInstance(exampleType);
            example.Run();
        }
        private static void Main(string[] args)
        {
            
            
            while (true)
            {
                Console.WriteLine(File.ReadAllText(@"..\..\DataStructures\Menu\DataStructuresAndAlgorithms.txt"));
                
                var choice = char.ToLower(Console.ReadKey().KeyChar);
                Console.Clear();
                var done = false;
                switch (choice)
                {
                    case '1':
                        while (!done)
                        {
                            Console.WriteLine(File.ReadAllText(@"..\..\DataStructures\Menu\Array.txt"));
                            choice = char.ToLower(Console.ReadKey().KeyChar);
                            Console.Clear();
                            switch (choice)
                            {
                                case '1':
                                    Run(typeof(SequenceArrayExample));
                                    break;
                                case '2':
                                    Run(typeof(VectorArrayExample));
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
                            Console.WriteLine(File.ReadAllText(@"..\..\DataStructures\Menu\LinkedList.txt"));
                            choice = char.ToLower(Console.ReadKey().KeyChar);
                            Console.Clear();
                            switch (choice)
                            {
                                case '1':
                                    Run(typeof(SinglyLinkedListExample));
                                    break;
                                case '2':
                                    Run(typeof(DoublyLinkedListExample));
                                    break;
                                case '3':
                                    Run(typeof(CircularLinkedListExample));
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
                            Console.WriteLine(File.ReadAllText(@"..\..\DataStructures\Menu\Stack.txt"));
                            choice = char.ToLower(Console.ReadKey().KeyChar);
                            Console.Clear();
                            switch (choice)
                            {
                                case '1':
                                    Run(typeof(ArrayStackExample));
                                    break;
                                case '2':
                                    Run(typeof(VectorStackExample));
                                    break;
                                case '3':
                                    Run(typeof(ListStackExample));
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
                            Console.WriteLine(File.ReadAllText(@"..\..\DataStructures\Menu\Queue.txt"));
                            choice = char.ToLower(Console.ReadKey().KeyChar);
                            Console.Clear();
                            switch (choice)
                            {
                                case '1':
                                    Run(typeof(ArrayQueueExample));
                                    break;
                                case '2':
                                    Run(typeof(VectorQueueExample));
                                    break;
                                case '3':
                                    Run(typeof(ListQueueExample));
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
                    case '5':
                        Run(typeof(RecursionExample));
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