using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class SeqQueue<T> : ISeqQueue<T>
    {
        T[] data;
        int prev;
        int end;
        int count;

        public SeqQueue(int size)
        {
            data = new T[size];
            prev = -1;
            end = -1;
            count = 0;
        }

        public SeqQueue() : this(10)
        {

        }


        public int Count
        {
            get
            {
                return count;
            }
        }

        public void Clear()
        {
            prev = end = -1;
            count = 0;
        }
        

        public T Dequeue()
        {
            if(prev >= data.Length)
            {
                prev = -1;
            }
            T value = data[prev + 1];
            prev++;
            count--;
            return value;
        }

        public void Enqueue(T item)
        {
            if(end >= data.Length)
            {
                end = -1;
            }
            data[end + 1] = item;
            end++;
            if(end < data.Length)
            {
                count++;
            }
        }

        public T Peek()
        {
            return data[prev + 1];
        }

        public bool IsEmpty()
        {
            throw new NotImplementedException();
        }
    }
}
