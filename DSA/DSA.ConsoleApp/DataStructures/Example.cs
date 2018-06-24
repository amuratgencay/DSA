using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DSA.ConsoleApp.DataStructures
{

    public abstract class Example<T>
    {
        protected readonly List<Action> Steps;
        public abstract void Init();
        protected Example()
        {
            Steps = new List<Action>();
        }

        protected Example(List<Action> steps)
        {
            Steps = steps;
        }

        public abstract void Header();
        public abstract void Footer();


        public void Run()
        {
            Init();

            Header();

            foreach (var example in Steps)
            {
                example.Invoke();
                Console.WriteLine();
            }

            Footer();
        }
    }
}
