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
            LinkStack s = new LinkStack();
            s.Push(4);
            s.Push(3);
            s.Push(2);
            s.Push(1);
            Console.WriteLine("元素 a,b,c,d  入栈之后，栈的元素个数：" + s.Count + "  栈的长度：" + s.Count);
            Console.WriteLine("-----------当前最小元素-----------：" + s.Min());
            Console.WriteLine("栈顶元素：" + s.Peek());
            Console.WriteLine("元素 " + s.Pop() + " 出栈之后，栈顶元素：" + s.Peek());
            Console.WriteLine("-----------当前最小元素-----------：" + s.Min());
            Console.WriteLine("元素 " + s.Pop() + " 出栈之后，栈顶元素：" + s.Peek());
            s.Push(4);
            s.Push(5);
            s.Push(6);
            Console.WriteLine("元素 e,f,g  入栈之后，栈的元素个数：" + s.Count + "  栈顶元素：" + s.Peek());
            Console.WriteLine("-----------当前最小元素-----------：" + s.Min());
            Console.WriteLine("元素 " + s.Pop() + ", " + s.Pop() + " 出栈之后，栈顶元素：" + s.Peek());
            Console.WriteLine("-----------当前最小元素-----------：" + s.Min());
            s.Clear();
            Console.WriteLine("清空栈之后，栈的元素个数：" + s.Count + "  栈的长度：" + s.Count);
            Console.WriteLine("-----------当前最小元素-----------：" + s.Min());
            Console.ReadKey();
        }
    }
}
