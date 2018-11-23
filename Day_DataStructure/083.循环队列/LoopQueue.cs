using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class LoopQueue<T> : ILoopQueue<T>
    {
        private int rear; //后
        private int foront; //前
        private T[] arr;
        private int MAXSIZE;


        public LoopQueue(int len)
        {
            arr = new T[len];
            rear = foront = 0;
            MAXSIZE = len;
        }

        public LoopQueue() : this(4)
        {
            
        }

        public int Count
        {
            get { return (rear - foront + MAXSIZE)%MAXSIZE; }
        }

        public void Clear()
        {
            rear = foront = 0;
        }
        

        public T Dequeue()
        {
            if (foront == rear)
            {
                Console.WriteLine("is null!");
                return default(T);
            }

            T value = arr[foront];
            foront = (foront + 1)%MAXSIZE;
            return value;
        }


        public void Enqueue(T item)
        {
            if ((rear + 1)%MAXSIZE == foront)
            {
                Console.WriteLine("is full! item is not InQueue:" + item);
                return;
            }

            arr[rear] = item;
            rear = (rear + 1)%MAXSIZE;
        }

        public bool IsEmpty() => foront == rear;


        public T Peek()
        {
            return arr[foront];
        }
    }
}
