using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public interface ILinkStack<T>
    {
        int Count { get; }
        T Peek();
        T Pop();
        void Push(T item);
        void Clear();
    }
}
