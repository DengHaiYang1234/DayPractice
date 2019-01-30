using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public interface ILickList<T>
    {
        void Clear();
        int GetLength();
        int Length { get; }
        void Add(T item);
        T Remove(T item);
        T RemoveAt(int index);
        void Insert(int index, T item);
        bool IsExist(T item);
        int IndexOf(T item);
    }
}
