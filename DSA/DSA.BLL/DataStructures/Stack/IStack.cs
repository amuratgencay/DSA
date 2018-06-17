namespace DSA.BLL.DataStructures.Stack
{
    public interface IStack<T> : ICluster<T>
    {
        bool IsEmpty { get; }
        bool IsFull { get; }
        void Push(T item);
        T Pop();
        T Peek();
    }
}