using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public static Stack<int> stack_1 = new Stack<int>();
        public static Stack<int> stack_2 = new Stack<int>();

        static void Main(string[] args)
        {
            Enqueue(1);
            Enqueue(2);
            Enqueue(3);
            Enqueue(4);
            Enqueue(5);
            Console.WriteLine("=======================");
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
            while (stack_1.Count > 0)
            {
                stack_2.Push(stack_1.Pop());
            }

            int value = stack_2.Pop();
            Console.WriteLine("Dequeu:" + value);
            return value;
        }
    }
}
