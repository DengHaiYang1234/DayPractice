using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            SeqQueue queue = new SeqQueue();
            queue.Enqueue(78);
            queue.Enqueue(24);
            queue.Enqueue(5);
            queue.Enqueue(18);
            queue.Enqueue(36);
            queue.Enqueue(6);
            queue.Enqueue(68);
            Console.WriteLine("Enqueue后队列的长度:" + queue.Count);

            var value = queue.Dequeue();
            Console.WriteLine("Dequeue的值:" + value);
            Console.WriteLine("Dequeue后队列的长度:" + queue.Count);
            //Console.WriteLine("Dequeue后是否为空:" + queue.IsEmpty());
            queue.Enqueue(18);

            var vPeek = queue.Peek();
            Console.WriteLine("Peek的值:" + vPeek);
            Console.WriteLine("Peek后队列的长度:" + queue.Count);


            var value1 = queue.Dequeue();
            Console.WriteLine("Dequeue的值:" + value1);
            Console.WriteLine("Dequeue后队列的长度:" + queue.Count);
            //Console.WriteLine("Dequeue后是否为空:" + queue.IsEmpty());
            queue.Enqueue(24);

            var v1Peek = queue.Peek();
            Console.WriteLine("Peek的值:" + v1Peek);
            Console.WriteLine("Peek后队列的长度:" + queue.Count);

        }
    }
}
