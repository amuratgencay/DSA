using DSA.BLL.DataStructures.LinkedList.DoublyLinkedList;

namespace DSA.BLL.DataStructures.LinkedList.CircularLinkedList
{
    public class CircularLinkedList<T> : DoublyLinkedList<T>
    {
        private void LinkLastToFirst()
        {
            var first = (DoublyListItem<T>)First;
            var last = (DoublyListItem<T>)Last;
            last.Next = (DoublyListItem<T>)First;
            first.Prev = (DoublyListItem<T>)Last;
        }

        public override void Add(T item)
        {
            base.Add(item);
            LinkLastToFirst();
        }

        public override void Insert(int index, T item)
        {
            base.Insert(index, item);
            LinkLastToFirst();
        }

        public override bool RemoveAt(int index)
        {
            var res = base.RemoveAt(index);
            if (Count > 0)
            {
                LinkLastToFirst();
            }

            return res;
        }
    }
}