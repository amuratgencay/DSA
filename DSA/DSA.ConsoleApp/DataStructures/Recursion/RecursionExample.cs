using DSA.ConsoleApp.DataStructures.Example;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rec = DSA.BLL.DataStructures.Recursion;
namespace DSA.ConsoleApp.DataStructures.Recursion
{
    public class RecursionExample : Example.Example
    {

        public override void Header()
        {
            Console.WriteLine($"<Recursion>\n");
        }

        public override void Footer()
        {
            Console.WriteLine($"</Recursion>\n");
        }

        public override void Init()
        {
            Steps.Add(Fibonacci);
            Steps.Add(Factorial);
            Steps.Add(Reverse);
        }

        public void Fibonacci()
        {
            Rec.Recursion recursion = new Rec.Recursion();
            Console.WriteLine($"\tFibonacci(0): {recursion.Fibonacci(0)}");
            Console.WriteLine($"\tFibonacci(1): {recursion.Fibonacci(1)}");
            Console.WriteLine($"\tFibonacci(2): {recursion.Fibonacci(2)}");
            Console.WriteLine($"\tFibonacci(3): {recursion.Fibonacci(3)}");
            Console.WriteLine($"\tFibonacci(4): {recursion.Fibonacci(4)}");
            Console.WriteLine($"\tFibonacci(5): {recursion.Fibonacci(5)}");
        }

        public void Factorial()
        {
            Rec.Recursion recursion = new Rec.Recursion();
            Console.WriteLine($"\tFactorial(0): {recursion.Factorial(0)}");
            Console.WriteLine($"\tFactorial(1): {recursion.Factorial(1)}");
            Console.WriteLine($"\tFactorial(2): {recursion.Factorial(2)}");
            Console.WriteLine($"\tFactorial(3): {recursion.Factorial(3)}");
            Console.WriteLine($"\tFactorial(4): {recursion.Factorial(4)}");
            Console.WriteLine($"\tFactorial(5): {recursion.Factorial(5)}");
        }

        public void Reverse()
        {
            Rec.Recursion recursion = new Rec.Recursion();
            Console.WriteLine($"\tReverse(text): {recursion.Reverse("Reverse Text")}");
        }
    }
}
