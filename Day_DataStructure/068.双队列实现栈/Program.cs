using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            Pop();
            Pop();
            Pop();
            Pop();
            Pop();
            Pop();
            Push(7);
            Push(8);
            Pop();
        }

        static void Push(int value)
        {
            Console.WriteLine("============入栈：" + value);
            queue_1.Enqueue(value);
        }

        static int Pop()
        {
            int value = -1;
            if (queue_1.Count > 0)
            {
                while (queue_1.Count > 1)
                {
                    int data = queue_1.Dequeue();
                    queue_2.Enqueue(data);
                }

                value = queue_1.Dequeue();

                while (queue_2.Count > 0)
                {
                    queue_1.Enqueue(queue_2.Dequeue());
                }
            }
            else
            {
                Console.WriteLine("队列为空!!");
            }
            Console.WriteLine("============出栈：" + value);
            return value;
        }
    }
}
