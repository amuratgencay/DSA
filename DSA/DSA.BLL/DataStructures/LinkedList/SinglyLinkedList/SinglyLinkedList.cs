namespace DSA.BLL.DataStructures.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedList<T> : LinkedList<T>
    {
        public override void Add(T item)
        {
            base.Add(new SinglyListItem<T>(item));
        }

        public virtual void Insert(int index, T item)
        {
            base.Insert(index, new SinglyListItem<T>(item));
        }
    }
}