using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class SeqBothStack<T>
    {
        private T[] arr;
        private int rear; //尾
        private int front; //头

        private int[] top = new int[2];

        public SeqBothStack(int len)
        {
            arr = new T[len];
            top[0] = -1;
            top[1] = len;
        }

        public SeqBothStack() : this(10)
        {
            
        }

        public int MaxSize
        {
            get { return arr.Length; }
        }

        public bool isEmpty() => (top[0] == -1) && (top[1] == MaxSize);

        public bool isEmpty(int i)
        {
            if (i > 1 || i < 0)
            {
                Console.WriteLine(i + "号栈不存在");
                return false;
            }

            if (i == 1)
                return top[1] == MaxSize;
            else
                return top[0] == -1;
        }

        public bool IsFull() => top[0] + 1 == top[1];

        public void Push(T item,int i)
        {
            if (IsFull())
            {
                Console.WriteLine("push is called but is full!");
                return;
            }

            if (i > 1 || i < 0)
            {
                Console.WriteLine(i + "号栈不存在！");
                return;
            }
            


            if (i == 0)
                arr[++top[0]] = item;
            else
                arr[--top[1]] = item;
        }

        public T Pop(int i)
        {
            if (i > 1 || i < 0)
            {
                Console.WriteLine(i + "号栈不存在！");
                return default(T);
            }

            return i == 0 ? arr[top[0]--] : arr[top[1]++];
        }

        public T Peek(int i)
        {
            if (i > 1 || i < 0)
            {
                Console.WriteLine(i + "号栈不存在！");
                return default(T);
            }

            return i == 0 ? arr[top[0]] : arr[top[1]];
        }

        public int Count() => (top[0] + 1) + (MaxSize - top[1]);

        public int Count(int i)
        {
            if (i > 1 || i < 0)
            {
                Console.WriteLine(i + "号栈不存在！");
                return -1;
            }

            return i == 0 ? (top[0] + 1) : (MaxSize - top[1]);
        }

        public void Clear()
        {
            top[0] = -1;
            top[1] = MaxSize;
        }

        public void Clear(int i)
        {
            if (i > 1 || i < 0)
            {
                Console.WriteLine(i + "号栈不存在！");
                return;
            }

            if (i == 1)
            {
                top[0] = -1;
            }
            else
                top[1] = MaxSize;

        }
    }
}
