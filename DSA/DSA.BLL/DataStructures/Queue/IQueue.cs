using System.Text;
using System.Threading.Tasks;

namespace DSA.BLL.DataStructures.Queue
{
    interface IQueue<T> : ICluster<T>
    {
        bool IsEmpty { get; }
        bool IsFull { get; }
        void Enqueue(T item);
        T Dequeue();
        T Peek();
    }

}
