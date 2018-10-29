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
            SeqQueue s = new SeqQueue();
            s.Enqueue(1233);
            s.Enqueue(241);
            s.Enqueue(313);
            s.Enqueue(442);
            s.Enqueue(52);
            s.Enqueue(653);

            s.Dequeue();
            s.Dequeue();
            s.Dequeue();
            s.Dequeue();
            s.Dequeue();
            s.GetMin();
        }
    }
}
