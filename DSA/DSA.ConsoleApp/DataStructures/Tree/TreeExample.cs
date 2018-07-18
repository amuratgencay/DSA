using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSA.BLL.DataStructures.Tree;

namespace DSA.ConsoleApp.DataStructures.Tree
{
    public class TreeExample : Example.Example
    {
        public override void Header()
        {
            Console.WriteLine($"<Tree>\n");
        }

        public override void Footer()
        {
            Console.WriteLine($"</Tree>\n");
        }

        public override void Init()
        {
            Steps.Add(TreeInit);
        }

        public void TreeInit()
        {
            var tree = new Tree<int>();
            tree.Add(27);
            tree.Add(14);
            tree.Add(35);
            tree.Add(10);
            tree.Add(19);
            tree.Add(31);
            tree.Add(42);
            Console.WriteLine(tree);
        }
    }
}
