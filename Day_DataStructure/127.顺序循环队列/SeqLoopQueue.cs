using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class SeqLoopQueue<T> : ISeqLoopQueue<T>
    {
        private T[] arr;
        private int rear; //尾
        private int front; //头
        private int MAXSIZE; 

        public SeqLoopQueue(int len)
        {
            arr = new T[len];
            rear = 0;
            front = 0;
            MAXSIZE = len;
        }
        
        public int Count
        {
            get { return (rear - front + MAXSIZE)%MAXSIZE; }
        }

        public void Clear()
        {
            rear = 0;
            front = 0;
        }

        public T Dequeue()
        {
            T value = arr[front++];
            front = front%MAXSIZE;
            return value;
        }

        public void Enqueue(T item)
        {
            if ((rear + 1)%MAXSIZE == 0)
            {
                Console.WriteLine("Full");
                return;
            }
            arr[rear++] = item;
            rear = rear%MAXSIZE;
        }

        public bool IsEmpty()
        {
            return (front == 0) && (rear == 0);
        }

        public T Peek()
        {
            return arr[front];
        }
    }
}
