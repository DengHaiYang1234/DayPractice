using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public interface ILinkStack<T>
    {
        void Clear();
        int Count { get; }
        void Push(T item);
        T Pop();
        T Peek();
    }
}
