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
            Stack<int> s1 = new Stack<int>();
            Stack<int> s2 = new Stack<int>();
            //入队列
            EnQueue(s1, s2, 1);
            EnQueue(s1, s2, 2);
            EnQueue(s1, s2, 3);
            EnQueue(s1, s2, 4);
            EnQueue(s1, s2, 5);
            //出队列
            DeQueue(s1, s2);
            DeQueue(s1, s2);
            DeQueue(s1, s2);
            DeQueue(s1, s2);
            DeQueue(s1, s2);
        }

        static void EnQueue(Stack<int> s1,Stack<int> s2,int m)
        {
            s1.Push(m);
            Console.WriteLine("入栈：" + m);
        }

        static void DeQueue(Stack<int> s1,Stack<int> s2)
        {
            if(s2.Count == 0)
            {
                int p = s1.Count;
                for(int i = 0;i < p ;i++)
                {
                    s2.Push(s1.Peek());
                    s1.Pop();
                }
            }
            int m = s2.Peek();
            s2.Pop();
            Console.WriteLine("出栈：" + m);
        }
    }
}
