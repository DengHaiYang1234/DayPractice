using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> q1 = new Queue<int>();
            Queue<int> q2 = new Queue<int>();
            StackPush(q1, q2, 1);
            StackPush(q1, q2, 2);
            StackPush(q1, q2, 3);
            StackPush(q1, q2, 4);
            StackPush(q1, q2, 5);
            Console.WriteLine("------------------------------------------");
            StaackPop(q1, q2);
            StaackPop(q1, q2);
            StaackPop(q1, q2);
            StaackPop(q1, q2);
            StaackPop(q1, q2);
        }


        static void StackPush(Queue<int> q1,Queue<int> q2,int m)
        {
            q1.Enqueue(m);
            Console.WriteLine("入栈：" + m);
        }


        static void StaackPop(Queue<int> q1,Queue<int> q2)
        {
            int p = q1.Count;
            for(int i =0;i< p - 1;i++)
            {
                q2.Enqueue(q1.Peek());
                q1.Dequeue();
            }
            int m = q1.Peek();
            q1.Dequeue();
            Console.WriteLine("出栈：" + m);
            int l = q2.Count;
            for(int j = 0;j < l;j++)
            {
                q1.Enqueue(q2.Peek());
                q2.Dequeue();
            }
        }

       
    }
}
