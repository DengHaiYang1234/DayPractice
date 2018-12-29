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
        private int rear;
        private int front;
        private int count;

        public SeqQueue(int len)
        {
            arr = new T[len];
            rear = 0;
            front = 0;
            count = 0;
        }

        public SeqQueue() : this(10)
        {
            
        }


        public int Count
        {
            get { return count; }
        }

        public void Clear()
        {
            rear = 0;
            front = 0;
            count = 0;
        }

        public T Dequeue()
        {
            T value = arr[front++];

            if (front >= count)
            {
                Console.WriteLine("Is Null!");
                return default(T);
            }
            count--;

            return value;
        }

        public void Enqueue(T item)
        {
            if (count >= arr.Length)
            {
                Console.WriteLine("is Full!");
                return;
            }

            arr[rear++] = item;
            count++;
        }

        public bool IsEmpty() => count == 0;
        

        public T Peek()
        {
            return arr[front];
        }
    }
}
