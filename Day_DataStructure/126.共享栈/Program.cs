using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ShareStack stack = new ShareStack(10);
            stack.Push(1, 0);
            stack.Push(2, 0);
            stack.Push(3, 0);
            stack.Push(1, 1);
            stack.Push(2, 1);
            stack.Push(3, 1);

            Console.WriteLine("1号栈Pop：" + stack.Pop(1));
            Console.WriteLine("1号栈Pop：" + stack.Pop(1));
            stack.Push(4, 1);
            Console.WriteLine("1号栈Peek：" + stack.Peek(1));

            Console.WriteLine("0号栈Pop：" + stack.Pop(0));
            Console.WriteLine("0号栈Pop：" + stack.Pop(0));
            stack.Clear(0);
            Console.WriteLine("0号栈Peek：" + stack.Peek(0));
        }
    }
}
