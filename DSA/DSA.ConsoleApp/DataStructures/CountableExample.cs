using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DSA.BLL.DataStructures;
using DSA.BLL.DataStructures.Search;
using DSA.BLL.DataStructures.Sort;
using DSA.BLL.DataStructures.Stack;

namespace DSA.ConsoleApp.DataStructures
{
    public class CountableExample<T> : Example<ICountable<T>> where T : IComparable
    {
        protected ICountable<T> Countable;
        private T _searchItem;
        private T _containsItem;
        private T _indexOfItem;
        private T _lastIndexOfItem;
        private int _setIndex;
        private T _setValue;
        private int _getIndex;
        protected Action BeforeStep;
        protected Action AfterStep;

        public override void Init()
        {
            if (BeforeStep != null)
                Steps.Add(BeforeStep);

            Steps.Add(ContainsExample);
            Steps.Add(IndexOfExample);
            Steps.Add(LastIndexOfExample);
            Steps.Add(ReverseExample);
            Steps.Add(CountExample);
            Steps.Add(SetExample);
            Steps.Add(GetExample);
            Steps.Add(ClearExample);

            if (AfterStep != null)
                Steps.Add(AfterStep);

            Steps.Add(SearchExample);
            Steps.Add(SortExample);
        }
        public override void Header()
        {
            var typeName = Countable.GetType().GetCleanTypeName();
            Console.WriteLine($"<{typeName}>\n");
        }

        public override void Footer()
        {
            var typeName = Countable.GetType().GetCleanTypeName();
            Console.WriteLine($"</{typeName}>\n");
        }

        public CountableExample(ICountable<T> countable, T searchItem, T containsItem, T indexOfItem, T lastIndexOfItem, int setIndex, T setValue, int getIndex, Action beforeStep = null, Action afterStep = null)
        {
            _searchItem = searchItem;
            Countable = countable;
            _containsItem = containsItem;
            _indexOfItem = indexOfItem;
            _lastIndexOfItem = lastIndexOfItem;
            _setIndex = setIndex;
            _setValue = setValue;
            _getIndex = getIndex;
            BeforeStep = beforeStep;
            AfterStep = afterStep;

        }

        public void ContainsExample()
        {
            Console.WriteLine($"\tContains -> ({_containsItem}): {Countable.Contains(_containsItem)}");
        }

        public void IndexOfExample()
        {
            Console.WriteLine($"\tIndexOf -> ({_containsItem}): {Countable.IndexOf(_indexOfItem)}");
        }

        public void LastIndexOfExample()
        {
            Console.WriteLine($"\tLastIndexOf -> ({_containsItem}): {Countable.LastIndexOf(_lastIndexOfItem)}");
        }

        public void ReverseExample()
        {
            Countable.Reverse();
            Console.WriteLine($"\tReverse -> {Countable.Count}");
        }

        public void CountExample()
        {
            Console.WriteLine($"\tCount -> {Countable.Count}");
        }

        public void SetExample()
        {
            Countable[_setIndex] = _setValue;
            Console.WriteLine($"\tSet[{_setIndex}] = {_setValue} -> {Countable}");
        }

        public void GetExample()
        {
            Console.WriteLine($"\tGet[{_getIndex}] -> {Countable[_getIndex]}");
        }

        public void ClearExample()
        {
            Countable.Clear();
            Console.WriteLine($"\tClear -> {Countable}");
        }
        public void SearchExample()
        {
            var searchType = typeof(ISearch<>);
            var search = new List<Type>(Assembly.GetAssembly(searchType).GetTypes())
                .Where(x => x.GetInterfaces().Any(y => y.Name == searchType.Name)).ToList();
            foreach (var type in search)
            {
                var genericType = type.MakeGenericType(typeof(T));
                var item = (ISearch<T>)Activator.CreateInstance(genericType);
                Console.WriteLine("\t" + genericType.GetCleanTypeName() + " -> " + item.Search(Countable, _searchItem));
                Console.WriteLine();
            }
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
        }

        public void SortExample()
        {
            var sortType = typeof(ISort<>);
            var sort = new List<Type>(Assembly.GetAssembly(sortType).GetTypes())
                .Where(x => x.GetInterfaces().Any(y => y.Name == sortType.Name)).ToList();
            foreach (var type in sort)
            {
                var genericType = type.MakeGenericType(typeof(T));
                var item = (ISort<T>)Activator.CreateInstance(genericType);
                Console.WriteLine("\t" + genericType.GetCleanTypeName() + " -> " + item.Sort(Countable));
                Console.WriteLine();
                Console.WriteLine("\tOriginal -> " + Countable);
                Console.WriteLine();
            }
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
        }

    }

    public abstract class ExtendedCountableExample<T> : CountableExample<T> where T : IComparable
    {
        public ExtendedCountableExample(ICountable<T> countable, T searchItem, T containsItem, T indexOfItem, T lastIndexOfItem, int setIndex, T setValue, int getIndex, Action beforeStep = null, Action afterStep = null) : base(countable, searchItem, containsItem, indexOfItem, lastIndexOfItem, setIndex, setValue, getIndex, beforeStep, afterStep)
        {

        }

        public abstract void TakeExample();
        public abstract void GetFirstExample();
        public abstract void IsFullExample();
        public abstract void IsEmptyExample();

        public override void Init()
        {
            if (BeforeStep != null)
                Steps.Add(BeforeStep);
            
            Steps.Add(ContainsExample);
            Steps.Add(IndexOfExample);
            Steps.Add(LastIndexOfExample);
            Steps.Add(GetFirstExample);
            Steps.Add(IsFullExample);
            Steps.Add(TakeExample);
            Steps.Add(ReverseExample);
            Steps.Add(CountExample);
            Steps.Add(SetExample);
            Steps.Add(GetExample);
            Steps.Add(ClearExample);
            Steps.Add(IsEmptyExample);

            if (AfterStep != null)
                Steps.Add(AfterStep);

            Steps.Add(SearchExample);
            Steps.Add(SortExample);
        }      

    }

    public class StackExample : ExtendedCountableExample<int>
    {
        private static IStack<int> _stack;

        public StackExample(IStack<int> stack) : base(stack, 5, 8, 13, 13, 1, 21, 2, FirstInit, SecondInit)
        {
            _stack = stack;
        }

        public static void FirstInit()
        {
            _stack.Push(2);
            _stack.Push(3);
            _stack.Push(5);
            _stack.Push(8);
            _stack.Push(13);
            Console.WriteLine("\tInit -> " + _stack);
        }

        public static void SecondInit()
        {
            _stack.Push(21);
            _stack.Push(8);
            _stack.Push(5);
            _stack.Push(13);

            Console.WriteLine("\tInit -> " + _stack);
        }

        public override void TakeExample()
        {
            Console.WriteLine("\tPop -> " + _stack.Pop());
        }

        public override void GetFirstExample()
        {
            Console.WriteLine("\tPeek -> " + _stack.Peek());
        }

        public override void IsFullExample()
        {
            Console.WriteLine("\tIsFull -> " + _stack.IsFull);
        }

        public override void IsEmptyExample()
        {
            Console.WriteLine("\tIsEmpty -> " + _stack.IsEmpty);
        }

    }


}