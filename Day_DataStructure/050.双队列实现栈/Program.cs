using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class Program
    {
        static Queue<int> queue_1 = new Queue<int>();
        static Queue<int> queue_2 = new Queue<int>();
        static void Main(string[] args)
        {
            Push(queue_1, 1);
            Push(queue_1, 2);
            Push(queue_1, 3);
            Push(queue_1, 4);
            Push(queue_1, 5);
            Push(queue_1, 6);

            Pop(queue_1, queue_2);
            Pop(queue_1, queue_2);
            Pop(queue_1, queue_2);
            Pop(queue_1, queue_2);
            Pop(queue_1, queue_2);
            Pop(queue_1, queue_2);
        }


        static void Push(Queue<int> queue,int item)
        {
            queue.Enqueue(item);
            Console.WriteLine("入栈：" + item);
        }

        static void Pop(Queue<int> queue1, Queue<int> queue2)
        {
            if (queue1.Count <= 0)
            {
                Console.WriteLine("栈为空");
                return;
            }

            while (queue1.Count > 1)
            {
                queue2.Enqueue(queue1.Dequeue());
            }

            int value = queue1.Dequeue();
            Console.WriteLine("出栈：" + value);

            while (queue2.Count > 0)
            {
                queue1.Enqueue(queue2.Dequeue());
            }
        }
    }
}
