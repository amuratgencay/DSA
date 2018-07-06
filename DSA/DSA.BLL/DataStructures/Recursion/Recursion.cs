using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.BLL.DataStructures.Recursion
{
    public class Recursion
    {
        public int Fibonacci(int x)
        {
            if (x < 2) return 1;
            return Fibonacci(x - 1) + Fibonacci(x - 2);
        }

        public int Factorial(int x)
        {
            if (x < 2) return 1;
            return x * Factorial(x - 1);
        }

        public string Reverse(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            return text[text.Length - 1] + Reverse(text.Remove(text.Length - 1, 1));
        }
       
    }


}
