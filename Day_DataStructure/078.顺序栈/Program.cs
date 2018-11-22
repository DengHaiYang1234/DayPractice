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
            SeqStack s = new SeqStack(30);
            s.Push(5);
            s.Push(2);
            s.Push(6);
            s.Push(1);
            Console.WriteLine("元素 5,2,6,1  入栈之后，栈的元素个数：" + s.Count + "  栈的长度：" + s.Count);
            Console.WriteLine("栈顶元素：" + s.Peek());
            Console.WriteLine("最小元素：" + s.GetMin());
            //Console.WriteLine("最大元素：" + s.GetMax());
            Console.WriteLine("元素 " + s.Pop() + " 出栈之后，栈顶元素：" + s.Peek());
            Console.WriteLine("最小元素：" + s.GetMin());
            Console.WriteLine("元素 " + s.Pop() + " 出栈之后，栈顶元素：" + s.Peek());
            Console.WriteLine("最小元素：" + s.GetMin());
            //Console.WriteLine("最大元素：" + s.GetMax());
            s.Push(5);
            s.Push(6);
            s.Push(7);
            Console.WriteLine("元素 5,6,7  入栈之后，栈的元素个数：" + s.Count + "  栈顶元素：" + s.Peek());
            Console.WriteLine("最小元素：" + s.GetMin());
            //onsole.WriteLine("最大元素：" + s.GetMax());
            Console.WriteLine("元素 " + s.Pop() + ", " + s.Pop() + " 出栈之后，栈顶元素：" + s.Peek());
            Console.WriteLine("最小元素：" + s.GetMin());
            //Console.WriteLine("最大元素：" + s.GetMax());
            s.Clear();
            Console.WriteLine("清空栈之后，栈的元素个数：" + s.Count + "  栈的长度：" + s.Count);
            Console.ReadKey();
        }
    }
}
