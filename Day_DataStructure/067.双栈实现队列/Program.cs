using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    //双栈实现队列
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
            Console.WriteLine("===============出队列===============");
            Console.WriteLine("======Dequeue:" + Dequeue());
            Console.WriteLine("======Dequeue:" + Dequeue());
            Console.WriteLine("======Dequeue:" + Dequeue());
            Console.WriteLine("======Dequeue:" + Dequeue());
            Enqueue(6);
            Console.WriteLine("======Dequeue:" + Dequeue());
        }


        static void Enqueue(int value)
        {
            Console.WriteLine("入队列:" + value);
            stack_1.Push(value);
        }

        static int Dequeue()
        {
            while (stack_1.Count > 0)
            {
                int value = stack_1.Pop();
                stack_2.Push(value);
            }

            return stack_2.Pop();
        }


        
    }
}
