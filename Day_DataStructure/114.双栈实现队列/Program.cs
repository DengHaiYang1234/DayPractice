using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class Program
    {
        private static Stack<int> stack_1 = new Stack<int>();
        private static Stack<int> stack_2 = new Stack<int>();

        static void Main(string[] args)
        {
            //TODO 先进先出  5 4 3 2 1
            Enqueue(5);
            Enqueue(4);
            Enqueue(3);
            Enqueue(2);
            Enqueue(1);
            Enqueue(10);
            Enqueue(15);
            Enqueue(16);
            Console.WriteLine("=======================================================");
            Dequeue();
            Dequeue();
            Dequeue();
            Dequeue();
            Dequeue();
            Dequeue();
            Dequeue();
            Dequeue();
            Dequeue();
        }

        static void Enqueue(int value)
        {
            stack_1.Push(value);
            Console.WriteLine("入队：" + value);
        }

        static int Dequeue()
        {
            while (stack_1.Count > 0)
            {
                stack_2.Push(stack_1.Pop());
            }

            if (stack_2.Count > 0)
            {
                Console.WriteLine("出队：" + stack_2.Peek());
                return stack_2.Pop();
            }
            return -1;

        }
    }
}
