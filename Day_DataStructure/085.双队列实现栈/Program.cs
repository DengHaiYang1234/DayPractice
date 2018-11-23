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
            Pop();
            Pop();
            Pop();
            Push(11);
            Push(22);
            Push(13);
            Push(23);
            Push(14);
            Push(24);
            Pop();
            Pop();
            Pop();
        }

        static void Push(int value)
        {
            queue_1.Enqueue(value);
            Console.WriteLine("Push:" + value);
        }

        static int Pop()
        {
            int value = -1;
            while (queue_1.Count > 1)
            {
                queue_2.Enqueue(queue_1.Dequeue());
            }

            if (queue_1.Count > 0)
            {
                value = queue_1.Dequeue();
                Console.WriteLine("=========Pop:" + value);
            }
            else
            {
                Console.WriteLine("is null");
            }

            while (queue_2.Count > 0)
                queue_1.Enqueue(queue_2.Dequeue());

            return value;
        }
    }
}
