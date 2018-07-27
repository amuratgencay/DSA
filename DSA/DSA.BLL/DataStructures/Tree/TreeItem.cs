using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.BLL.DataStructures.Tree
{

    public class TreeItem<T> where T : IComparable
    {
        public T Value { get; set; }
        public TreeItem<T> Left { get; set; }
        public TreeItem<T> Right { get; set; }
        public int Level { get; private set; }
        public TreeItem(T item, int level)
        {
            Value = item;
            Level = level;
        }
        public TreeItem(TreeItem<T> item)
        {
            Value = item.Value;
            Level = item.Level;
            Right = item.Right;
            Left = item.Left;
        }
    }
    public interface ITree<T> where T : IComparable
    {
        void Add(T item);
        bool Contains(T item);
        List<List<TreeItem<T>>> ToList();
    }
    public class Tree<T> : ITree<T> where T : IComparable
    {
        private TreeItem<T> _root;
        public int Level { get; private set; }
        public int Count { get; private set; }

        public Tree()
        {
            Level = -1;
        }

        private void AddRecursive(TreeItem<T> root, T item, ref int level)
        {
            if (root.Value.CompareTo(item) < 0)
            {
                if (root.Right == null)
                {
                    root.Right = new TreeItem<T>(item, level);
                }
                else
                {
                    level++;
                    AddRecursive(root.Right, item, ref level);
                }
            }
            else
            {
                if (root.Left == null)
                {
                    root.Left = new TreeItem<T>(item, level);
                }
                else
                {
                    level++;
                    AddRecursive(root.Left, item, ref level);
                }
            }
        }
        public void Add(T item)
        {
            if (_root == null)
            {
                _root = new TreeItem<T>(item, 0);
                Level++;
            }
            else
            {
                int level = 1;
                AddRecursive(_root, item, ref level);
                Level = level;

            }
            Count++;
        }

        private bool ContainsRecursive(TreeItem<T> root, T item)
        {
            if (root == null) return false;
            if (root.Value.CompareTo(item) < 0)
            {
                return ContainsRecursive(root.Right, item);
            }
            else if (root.Value.CompareTo(item) > 0)
            {
                return ContainsRecursive(root.Left, item);
            }
            return true;
        }

        public bool Contains(T item)
        {
            return ContainsRecursive(_root, item);
        }

        private void ToListRecursive(List<List<TreeItem<T>>> result, TreeItem<T> root, int level)
        {
            if (root == null) return;
            while (result.Count <= level)
            {
                result.Add(new List<TreeItem<T>>());
            }
            ToListRecursive(result, root.Left, level + 1);
            ToListRecursive(result, root.Right, level + 1);
            result[level].Add(root);
        }
        public List<List<TreeItem<T>>> ToList()
        {
            var res = new List<List<TreeItem<T>>>();
            ToListRecursive(res, _root, 0);
            return res;
        }

        private string StringCopy(string str, int count)
        {
            var res = "";
            for (int i = 0; i < count; i++)
            {
                res += str;
            }
            return res;
        }

        public override string ToString()
        {
            var res = "";
            var i = Level;
            foreach (var list in ToList())
            {
                if (list.Count > 0)
                    res+= "\t" + (list[0].Level + ".\t");
                var tabCount = (int)(Math.Pow(2, i) - 1);
                res += "\t" + (StringCopy("\t", tabCount));
                foreach (var item in list)
                {
                    res += (item.Value);
                    tabCount = (int)(Math.Pow(2, i + 1));
                    res += (StringCopy("\t", tabCount));
                }
                i--;
                res += "\n";
            }
            return res;
        }
    }
}
