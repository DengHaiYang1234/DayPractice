using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class SeqLoopQueue<T> : ISeqLoopQueue<T>
    {
        private T[] arr;

        private int MAXSIZE;
        private int pre;
        private int rear;

        public SeqLoopQueue(int len)
        {
            MAXSIZE = len;
            pre = 0;
            rear = 0;
            arr = new T[len];
        }

        public int Count
        {
            get { return ((MAXSIZE - pre) + rear)%MAXSIZE; }
        }

        public void Clear()
        {
            pre = 0;
            rear = 0;
        }

        public T Dequeue()
        {
            pre = pre % MAXSIZE;
            T value = arr[pre++];
            return value;
        }

        public void Enqueue(T item)
        {
            if ((rear + 1)%MAXSIZE == pre)
            {
                Console.WriteLine("is Full");
                return;
            }
            rear = rear % MAXSIZE;
            arr[rear++] = item;
        }

        public bool IsEmpty() => Count == 0;
        

        public T Peek()
        {
            return arr[pre];
        }
    }
}
