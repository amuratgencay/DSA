namespace DSA.BLL.DataStructures.Queue
{
    internal interface IQueue<T> : ICountable<T>
    {
        bool IsEmpty { get; }
        bool IsFull { get; }
        void Enqueue(T item);
        T Dequeue();
        T Peek();
    }
}