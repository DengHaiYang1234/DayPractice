using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class SeqStack<T> : ISeqStack<T>
    {
        T[] data;
        int top;

        public SeqStack(int len)
        {
            data = new T[len];
            top = -1;
        }

        public SeqStack() : this(10)
        {

        }

        public int Count
        {
            get
            {
                int temp = top;
                return ++temp;
            }
        }

        public void Clear() => top = -1;
        
        public T Peek()
        {
            T value = default(T);
            value = data[top];
            return value;
        }

        public T Pop()
        {
            T value = default(T);
            value = data[top];
            top--;
            return value;
        }

        public void Push(T item)
        {
            data[top + 1] = item;
            top++;
        }
    }
}
