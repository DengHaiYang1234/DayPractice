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
            Enqueue(1);
            Enqueue(2);
            Enqueue(3);
            Enqueue(4);
            Enqueue(5);
            Enqueue(6);
            Enqueue(7);
            DeQueue();
            DeQueue();
            DeQueue();
            DeQueue();
            Enqueue(8);
            Enqueue(9);
            DeQueue();
        }

        static void Enqueue(int value)
        {
            stack_1.Push(value);
            Console.WriteLine("Enqueue:" + value);
        }


        static int DeQueue()
        {
            while (stack_1.Count > 0)
            {
                stack_2.Push(stack_1.Pop());
            }

            int value = -1;

            if (stack_2.Count > 0)
            {
                value = stack_2.Pop();
            }
            else
            {
                Console.WriteLine("null");
            }
            Console.WriteLine("===========Dequeue:" + value);
            return value;
        }
    }
}
