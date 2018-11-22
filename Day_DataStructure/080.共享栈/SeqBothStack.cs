using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class SeqBothStack<T>
    {
        private T[] data;

        //两个共享栈
        private int[] top = new int[2];

        public SeqBothStack(int size)
        {
            data = new T[size];
            top[0] = -1;  //左栈起始位置
            top[1] = size; //右栈起始位置
        }

        public SeqBothStack() : this(10)
        {
            
        }

        public int MaxSize
        {
            get { return data.Length; }
        }


        public bool IsEmpty() => (top[0] == -1) && (top[1] == MaxSize);

        public bool IsEmpty(int i)
        {
            bool isEmpty = false;
            switch (i)
            {
                case 0:
                    isEmpty = top[0] == -1 ? true : false;
                    break;

                case 1:
                    isEmpty = top[1] == MaxSize ? true : false; 
                    break;
                default:
                    throw new Exception(i + "号栈，不存在");
            }

            return isEmpty;
        }

        public bool IsFull() => top[0] + 1 == top[1];


        public void Push(T item, int i)
        {
            if (IsFull())
            {
                Console.WriteLine("push is called but is full!");
                return;
            }

            switch (i)
            {
                case 0:
                    data[++top[0]] = item;
                    break;
                case 1:
                    data[--top[1]] = item;
                    break;
                default:
                    throw new Exception(i + "号栈，不存在");
            }
        }

        public T Pop(int i)
        {
            if (IsEmpty(i)) throw new Exception("Pop is call but is null.stack:" + i);

            return i == 0 ? data[top[0]--] : data[top[1]++];
        }

        public T Peek(int i)
        {
            if (IsEmpty(i)) throw new Exception("Pop is call but is null.stack:" + i);

            return i == 0 ? data[top[0]] : data[top[1]];
        }

        public int Count() => (top[0] + 1) + (MaxSize - top[1]);


        public int Count(int i)
        {
            if (i < 0 || i > 1) throw new Exception(i + "号栈，不存在");

            return i == 0 ? (top[0] + 1) : (MaxSize - top[1]);
        }

        public void Clear()
        {
            top[0] = -1;
            top[1] = MaxSize;
        }

        public void Clear(int i)
        {
            if (i < 0 || i > 1) throw new Exception(i + "号栈，不存在");
            if (i == 0)
                top[0] = -1;
            else top[1] = MaxSize;
        }
    }
}
