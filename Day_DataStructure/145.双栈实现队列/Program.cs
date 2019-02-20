using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//双栈实现队列
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
            Enqueue(8);
            Enqueue(4);
            Enqueue(5);
            Console.WriteLine("==========================");
            Dequeue();
            Dequeue();
            Dequeue();
            Dequeue();
            Dequeue();
            Dequeue();
        }

        static void Enqueue(int value)
        {
            Console.WriteLine("Enqueue:" + value);
            stack_1.Push(value);
        }

        static int Dequeue()
        {
            int data = -1;
            while (stack_1.Count > 1)
            {
                stack_2.Push(stack_1.Pop());
            }

            if (stack_1.Count > 0)
            {
                data = stack_1.Pop();
                Console.WriteLine("Dequeue:" + data);
            }

            while (stack_2.Count > 0)
            {
                stack_1.Push(stack_2.Pop());
            }

            return data;
        }
    }
}
