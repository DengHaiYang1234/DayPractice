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
        bool Contains(T item);
        T Peek();
        T Pop();
        void Push(T item);
        int Count { get; }
    }
}
