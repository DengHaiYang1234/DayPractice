using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//双队列实现栈
namespace project
{
    class Program
    {
        private static Queue<int> queue_1 = new Queue<int>();
        private static Queue<int> queue_2 = new Queue<int>();

        static void Main(string[] args)
        {
            Push(1);
            Push(2);
            Push(3);
            Push(4);
            Push(5);
            Console.WriteLine("======================");
            Pop();
            Pop();
            Pop();
            Pop();
            Pop();
        }

        static void Push(int value)
        {
            Console.WriteLine("Push:" + value);
            queue_1.Enqueue(value);
        }

        static void Pop()
        {
            while (queue_1.Count > 1)
            {
                queue_2.Enqueue(queue_1.Dequeue());
            }

            if (queue_1.Count > 0)
            {
                Console.WriteLine(queue_1.Dequeue());
            }

            while (queue_2.Count > 0)
            {
                queue_1.Enqueue(queue_2.Dequeue());
            }
        }

    }
}
