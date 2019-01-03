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
        private static  Queue<int> queue_2 = new Queue<int>();


        static void Main(string[] args)
        {
            Push(5);
            Push(4);
            Push(3);
            Push(2);
            Push(1);
            Console.WriteLine("========================================");
            Pop();
            Pop();
            Pop();
            Pop();
            Pop();
        }

        static void Push(int value)
        {
            queue_1.Enqueue(value);
            Console.WriteLine("入栈：" + value);
        }

        static int Pop()
        {
            while (queue_1.Count > 1)
            {
                queue_2.Enqueue(queue_1.Dequeue());
            }
            int value = -1;

            if (queue_1.Count > 0)
            {
               value = queue_1.Dequeue();
                Console.WriteLine("出栈：" + value);
            }
            

            while (queue_2.Count > 0)
            {
                queue_1.Enqueue(queue_2.Dequeue());
            }

            return value;

        }
    }
}
