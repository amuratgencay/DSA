namespace DSA.BLL.DataStructures.LinkedList.DoublyLinkedList
{
    public class DoublyLinkedList<T> : LinkedList<T>
    {
        protected new DoublyListItem<T> First {
            get => (DoublyListItem<T>)base.First;
            set =>  base.First = value;
        }
        protected new DoublyListItem<T> Last {
            get => (DoublyListItem<T>)base.Last;
            set => base.Last = value;
        }

        public virtual void Add(T item)
        {
            var oldLast = Last;
            base.Add(new DoublyListItem<T>(item));
            if (Count > 0)
            {
                var last = Last;
                last.Prev = oldLast;
            }
        }

        public virtual void Insert(int index, T item)
        {
            var first = First;
            var last = Last;

            if (index == 0)
                first.Prev = null;
            else if (index == Count - 1) last.Prev = null;

            base.Insert(index, new DoublyListItem<T>(item));
        }

        public override bool RemoveAt(int index)
        {
            var first = First;
            var last = Last;

            if (index == 0)
                first.Prev = null;
            else if (index == Count - 1) last.Prev = null;

            return base.RemoveAt(index);
        }
    }
}