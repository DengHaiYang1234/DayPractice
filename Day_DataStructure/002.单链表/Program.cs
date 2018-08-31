using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单链表
{
	class Program
	{
		static void Main(string[] args)
		{
			LinkListDS<int> a = new LinkListDS<int>();
			a.Add(1);
			a.Add(18);
			a.Add(89);
			a.Remove(18);
			a.Add(55);
			a.Add(56);
			a.Add(57);
			a.Add(58);
			a.Insert(2, 6666);
			Console.WriteLine("---------------SeqList-------------");
			Console.WriteLine("Count:" + a.Count);
			int len = a.Count;
			Console.WriteLine("len:" + len);
			for (int i = 0; i < len; i++)
			{
				Console.WriteLine("iiiiiiii:" + i);
				Console.WriteLine("a[i]:" + a[i]);
			}
		}
	}
}
