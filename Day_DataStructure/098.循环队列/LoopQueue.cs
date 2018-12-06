using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class LoopQueue<T> : ILoopQueue<T>
    {
        private T[] arr;
        private int front;
        private int rear;
        private int MAXSIZE;

        public LoopQueue(int len)
        {
            arr = new T[len];
            front = rear = 0;
            MAXSIZE = len;
        }

        public LoopQueue() : this(5)
        {
            
        }

        public int Count
        {
            get { return (rear - front + MAXSIZE)%MAXSIZE; }
        }

        public void Clear()
        {
            front = rear = 0;
        }

        public T Dequeue()
        {
            T value = arr[front];
            front = (front + 1) & MAXSIZE;
            return value;
        }

        public void Enqueue(T item)
        {
            if (((rear + 1)%MAXSIZE) == front)
            {
                Console.WriteLine("Is Full");
                return;
            }

            arr[rear] = item;
            rear = (rear + 1)%MAXSIZE;
        }

        public bool IsEmpty()
        {
            return (rear == 0) && (front == 0);
        }

        public T Peek()
        {
            return arr[front];
        }
    }
}
