using System;
using DSA.BLL.DataStructures;

namespace DSA.ConsoleApp.DataStructures.Example
{
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


}