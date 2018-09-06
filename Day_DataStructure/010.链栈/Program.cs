using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
	class Program
	{
		static void Main(string[] args)
		{
			LinkStackDS<char> s = new LinkStackDS<char>();
			s.Push('a');
			s.Push('b');
			s.Push('c');
			s.Push('d');
			Console.WriteLine("元素 a,b,c,d  入栈之后，栈的元素个数：" + s.Count + "  栈的长度：" + s.Count);
			Console.WriteLine("栈顶元素：" + s.Peek());
			Console.WriteLine("元素 " + s.Pop() + " 出栈之后，栈顶元素：" + s.Peek());
			Console.WriteLine("元素 " + s.Pop() + " 出栈之后，栈顶元素：" + s.Peek());
			s.Push('e');
			s.Push('f');
			s.Push('g');
			Console.WriteLine("元素 e,f,g  入栈之后，栈的元素个数：" + s.Count + "  栈顶元素：" + s.Peek());
			Console.WriteLine("元素 " + s.Pop() + ", " + s.Pop() + " 出栈之后，栈顶元素：" + s.Peek());
			s.Clear();
			Console.WriteLine("清空栈之后，栈的元素个数：" + s.Count + "  栈的长度：" + s.Count);
			Console.ReadKey();


		}
	}
}
