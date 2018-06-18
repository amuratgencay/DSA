namespace DSA.BLL.DataStructures.Array
{
    public class Vector<T> : ExpandedCountableArray<T>
    {
        public Vector()
        {
        }

        public Vector(int count) : base(count)
        {
        }

        public Vector(int count, int factor) : base(count, factor)
        {
        }

        public override void Clear()
        {
            base.Clear();
            Index = 0;
        }

        public new void Add(T item)
        {
            base.Add(item);
        }

        public new void Insert(int index, T item)
        {
            base.Insert(index, item);
        }

        public new bool Remove(T item)
        {
            return base.Remove(item);
        }

        public new bool RemoveAt(int index)
        {
            return base.RemoveAt(index);
        }
    }
}