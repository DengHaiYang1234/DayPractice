using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class SeqQueue<T> : ISeqQueue<T>
    {
        private T[] arr;
        private int top;
        private int tail;
        private int count;

        public SeqQueue(int len)
        {
            arr = new T[len];
            top = -1;
            tail = -1;
            count = 0;
        }

        public int Count
        {
            get { return count; }
        }

        public void Clear()
        {
            top = tail = -1;
            count = 0;
        }

        public T Dequeue()
        {
            if (top >= arr.Length - 1)
            {
                Console.WriteLine("is null");
                return default(T);
            }
            T value = arr[top + 1];
            top++;
            count--;
            return value;
        }

        public void Enqueue(T item)
        {
            if (count >= arr.Length)
            {
                Console.WriteLine("is full!!");
                return;
            }
            arr[tail + 1] = item;
            tail++;
            count++;
        }

        public bool IsEmpty() => count == 0;
        
        public T Peek()
        {
            return arr[top + 1];
        }
    }
}
