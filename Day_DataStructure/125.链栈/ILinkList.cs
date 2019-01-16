using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public interface ILinkList<T>
    {
        int Count { get; }
        T Peek();
        T Pop();
        void Push(T item);
        void Clear();
    }
}
