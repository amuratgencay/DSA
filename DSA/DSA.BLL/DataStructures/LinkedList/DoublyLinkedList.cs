using System;

namespace DSA.BLL.DataStructures.LinkedList
{
    public class DoublyLinkedList<T>
    {
        public DoublyLinkedList(T item)
        {
            Item = item;
        }

        public T Item { get; set; }

        public DoublyLinkedList<T> Next { get; set; }
        public DoublyLinkedList<T> Prev { get; set; }

        public static DoublyLinkedList<T> operator ++(DoublyLinkedList<T> linkedList)
        {
            if (linkedList == null)
                throw new ArgumentNullException(nameof(linkedList));
            return linkedList?.Next;
        }
    }
}