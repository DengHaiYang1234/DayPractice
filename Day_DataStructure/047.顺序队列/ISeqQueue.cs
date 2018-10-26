using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public interface ISeqQueue
    {
        void Clear();
        int Count { get; }
        void Enqueue(int item);
        int Dequeue();
        int Peek();
        bool IsEmpty();
    }
}
