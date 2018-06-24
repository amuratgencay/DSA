using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DSA.BLL.DataStructures;
using DSA.BLL.DataStructures.Search;
using DSA.BLL.DataStructures.Sort;

namespace DSA.ConsoleApp.DataStructures
{
    public class CountableExample<T> : Example<ICountable<T>> where T : IComparable
    {
        private ICountable<T> _countable;
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
            var typeName = _countable.GetType().GetCleanTypeName();
            Console.WriteLine($"<{typeName}>\n");
        }

        public override void Footer()
        {
            var typeName = _countable.GetType().GetCleanTypeName();
            Console.WriteLine($"</{typeName}>\n");
        }

        public CountableExample(ICountable<T> countable, T searchItem, T containsItem, T indexOfItem, T lastIndexOfItem, int setIndex, T setValue, int getIndex, Action beforeStep = null, Action afterStep = null)
        {
            _searchItem = searchItem;
            _countable = countable;
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
            Console.WriteLine($"\tContains -> ({_containsItem}): {_countable.Contains(_containsItem)}");
        }

        public void IndexOfExample()
        {
            Console.WriteLine($"\tIndexOf -> ({_containsItem}): {_countable.IndexOf(_indexOfItem)}");
        }

        public void LastIndexOfExample()
        {
            Console.WriteLine($"\tLastIndexOf -> ({_containsItem}): {_countable.LastIndexOf(_lastIndexOfItem)}");
        }

        public void ReverseExample()
        {
            _countable.Reverse();
            Console.WriteLine($"\tReverse -> {_countable.Count}");
        }

        public void CountExample()
        {
            Console.WriteLine($"\tCount -> {_countable.Count}");
        }

        public void SetExample()
        {
            _countable[_setIndex] = _setValue;
            Console.WriteLine($"\tSet[{_setIndex}] = {_setValue} -> {_countable}");
        }

        public void GetExample()
        {
            Console.WriteLine($"\tGet[{_getIndex}] -> {_countable[_getIndex]}");
        }

        public void ClearExample()
        {
            _countable.Clear();
            Console.WriteLine($"\tClear -> {_countable}");
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
                Console.WriteLine("\t" + genericType.GetCleanTypeName() + " -> " + item.Search(_countable, _searchItem));
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
                Console.WriteLine("\t" + genericType.GetCleanTypeName() + " -> " + item.Sort(_countable));
                Console.WriteLine();
                Console.WriteLine("\tOriginal -> " + _countable);
                Console.WriteLine();
            }
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
        }

    }

    public class StackAndQueueExample<T> : CountableExample<T> where T : IComparable
    {
        public StackAndQueueExample(ICountable<T> countable, T searchItem, T containsItem, T indexOfItem, T lastIndexOfItem, int setIndex, T setValue, int getIndex, Action beforeStep = null, Action afterStep = null) : base(countable, searchItem, containsItem, indexOfItem, lastIndexOfItem, setIndex, setValue, getIndex, beforeStep, afterStep)
        {

        }

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
    }
}