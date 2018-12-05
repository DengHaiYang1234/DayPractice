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
        
        public SeqQueue(int size)
        {
            arr = new T[size];
            rear = front = 0;
            count = 0;
        }
        
        public int Count
        {
            get { return count; }
        }

        public void Clear()
        {
            count = 0;
            rear = front = -1;
        }

        public T Dequeue()
        {
            if (count <= 0)
            {
                Console.WriteLine("空的");
                return default(T);
            }
            T value = arr[front];
            front++;
            count--;
            return value;
        }

        public void Enqueue(T item)
        {
            if (count > arr.Length)
            {
                Console.WriteLine("已满");
                return;
            }
            arr[rear] = item;
            rear++;
            count++;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public T Peek()
        {
            return arr[front];
        }
    }
}
