using System;

namespace DSA.BLL.DataStructures.LinkedList
{
    public class DoublyLinkedListItem<T>
    {
        public DoublyLinkedListItem(T item)
        {
            Item = item;
        }

        public T Item { get; set; }

        public DoublyLinkedListItem<T> Next { get; set; }
        public DoublyLinkedListItem<T> Prev { get; set; }

        public static DoublyLinkedListItem<T> operator ++(DoublyLinkedListItem<T> linkedList)
        {
            if (linkedList == null)
                throw new ArgumentNullException(nameof(linkedList));
            return linkedList?.Next;
        }
    }
}