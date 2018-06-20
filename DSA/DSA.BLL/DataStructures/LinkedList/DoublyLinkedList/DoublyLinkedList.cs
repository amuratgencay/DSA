namespace DSA.BLL.DataStructures.LinkedList.DoublyLinkedList
{
    public class DoublyLinkedList<T> : LinkedList<T>
    {
        public virtual void Add(T item)
        {
            var oldLast = (DoublyListItem<T>) Last;
            base.Add(new DoublyListItem<T>(item));
            if (Count > 0)
            {
                var last = (DoublyListItem<T>) Last;
                last.Prev = oldLast;
            }
        }

        public virtual void Insert(int index, T item)
        {
            var first = (DoublyListItem<T>) First;
            var last = (DoublyListItem<T>) Last;

            if (index == 0)
                first.Prev = null;
            else if (index == Count - 1) last.Prev = null;

            base.Insert(index, new DoublyListItem<T>(item));
        }

        public override bool RemoveAt(int index)
        {
            var first = (DoublyListItem<T>) First;
            var last = (DoublyListItem<T>) Last;

            if (index == 0)
                first.Prev = null;
            else if (index == Count - 1) last.Prev = null;

            return base.RemoveAt(index);
        }
    }
}