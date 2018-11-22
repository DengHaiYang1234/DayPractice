using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public interface ISeqStack
    {
        int Count { get; }
        int Peek();
        int Pop();
        void Push(int item);
        void Clear();
    }
}
