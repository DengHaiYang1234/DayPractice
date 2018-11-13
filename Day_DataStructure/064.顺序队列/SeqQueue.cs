using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
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
            top = 0;
            tail = 0;
            count = 0;
        }

        public SeqQueue() : this(3)
        {
            
        }


        public int Count
        {
            get { return count; }
        }

        public void Clear()
        {
            top = tail = 0;
            count = 0;
        }

        public T Dequeue()
        {
            if (top < 0)
            {
                Console.WriteLine("数组越界");
                return default(T);
            }

            if (top >= arr.Length)
            {
                top = 0;
            }
            T value = arr[top];
            top++;
            count--;
            return value;
        }

        public void Enqueue(T item)
        {
            if (tail >= arr.Length)
            {
                tail = 0;
                count = arr.Length;
            }

            arr[tail] = item;
            tail++;
            if (count != arr.Length)
            {
                count++;
            }
        }

        public bool IsEmpty() => count == 0;
        
        public T Peek()
        {
            return arr[top];
        }
    }
}
