using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class LinkStack : ILinkStack
    {
        int[] data;
        int[] min;
        int top;

        public LinkStack(int len)
        {
            data = new int[len];
            top = -1;
        }

        public LinkStack() : this(30)
        {

        }

        public int Count
        {
            get
            {
                int s = top;
                return ++s;
            }
        }

        public void Clear() => top = -1;
        

        public int Min()
        {
            if(top == -1)
            {
                Console.WriteLine("栈为空");
                return -1;
            }
            return min[top];
        }

        public int Peek()
        {
            return data[top];
        }

        public int Pop()
        {
            int value = data[top];
            top--;
            return value;
        }

        public void Push(int item)
        {
            data[top + 1] = item;
            top++;
            min = data;
            Sort(min);
        }

        public void Sort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = arr.Length - 1; j > 0; j--)
                {
                    if (arr[i] < arr[j])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

        }

    }
}
