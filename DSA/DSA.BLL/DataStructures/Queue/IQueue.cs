namespace DSA.BLL.DataStructures.Queue
{
    public interface IQueue<T> : ICountable<T>
    {
        bool IsEmpty { get; }
        bool IsFull { get; }
        void Enqueue(T item);
        T Dequeue();
        T Peek();
    }
}