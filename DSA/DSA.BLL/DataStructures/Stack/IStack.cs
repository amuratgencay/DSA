namespace DSA.BLL.DataStructures.Stack
{
    public interface IStack<T> : ICountable<T>
    {
        bool IsEmpty { get; }
        bool IsFull { get; }
        void Push(T item);
        T Pop();
        T Peek();
    }
}