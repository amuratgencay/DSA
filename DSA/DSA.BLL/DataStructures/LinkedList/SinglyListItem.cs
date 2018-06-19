using System;

namespace DSA.BLL.DataStructures.LinkedList
{
    public class SinglyListItem<T>
    {
        public SinglyListItem(T item)
        {
            Item = item;
        }

        public T Item { get; set; }

        public SinglyListItem<T> Next { get; set; }

        public static SinglyListItem<T> operator ++(SinglyListItem<T> singlyListItem)
        {
            if (singlyListItem == null)
                throw new ArgumentNullException(nameof(singlyListItem));
            return singlyListItem?.Next;
        }
    }
}