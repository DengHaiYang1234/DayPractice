using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public interface ILinkStack
    {
        void Clear();
        int Count { get; }
        void Push(int item);
        int Pop();
        int Peek();
        int Min();
    }
}
