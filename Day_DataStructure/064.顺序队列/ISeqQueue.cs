using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public interface ISeqQueue<T>
    {
        void Clear();
        int Count { get; }
        void Enqueue(T item);
        T Dequeue();
        T Peek();
        bool IsEmpty();
    }
}
