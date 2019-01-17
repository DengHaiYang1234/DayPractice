using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class ShareStack
    {
        private int[] arr;
        private int rear;//尾
        private int front;//头
        private int[] top = new int[2];
        private int MAXSIZE = 0;

        public ShareStack(int len)
        {
            arr = new int[len];
            front = -1;
            rear = len;
            top[0] = front;
            top[1] = rear;
            MAXSIZE = len;
        }

        public int GetCount()
        {
            return (top[0] + 1) + (MAXSIZE - top[1]);
        }

        public bool IsFull()
        {
            return GetCount() >= MAXSIZE;
        }

        public bool IsNull(int stack)
        {
            return stack == 0 ? (top[0] == -1) : (top[1] == MAXSIZE);
        }

        public void Push(int value,int stack)
        {
            if (IsFull())
            {
                Console.WriteLine("Full");
                return;
            }

            if (stack == 0)
            {
                arr[++top[0]] = value;
            }
            else
                arr[--top[1]] = value;
        }

        public int Pop(int stack)
        {
            if (IsNull(stack))
            {
                Console.WriteLine("null");
                return -1;
            }

            return stack == 0 ? (arr[top[0]--]) : (arr[top[1]++]);
        }

        public int Peek(int stack)
        {
            if (IsNull(stack))
            {
                Console.WriteLine("null");
                return -1;
            }

            return stack == 0 ? (arr[top[0]]) : (arr[top[1]]);
        }

        public void Clear()
        {
            top[0] = 0;
            top[1] = MAXSIZE - 1;
        }

        public void Clear(int stack)
        {
            if (stack == 0)
                top[0] = -1;
            else
                top[1] = MAXSIZE;
        }
    }
}
