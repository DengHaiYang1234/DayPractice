using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class SeqQueue<T> : ISeqQueue<T>
    {
        private int front;
        private int rear;
        private int MAXSIZE;
        private T[] arr;

        public SeqQueue(int size)
        {
            arr = new T[size];
            MAXSIZE = size;
            front = rear = 0;
        }

        public SeqQueue() : this(5)
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
            if (front == rear)
            {
                Console.WriteLine("队列为空");
                return default(T);
            }

            T value = arr[front];
            front = (front + 1)%MAXSIZE;
            return value;
        }

        public void Enqueue(T item)
        {
            if ((rear + 1)%MAXSIZE == front)
            {
                Console.WriteLine("队列 已满");
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
