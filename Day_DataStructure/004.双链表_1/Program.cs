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
			DoubleLink<int> dlink = new DoubleLink<int>();
			Console.WriteLine("将 10 插入到表头之后");
			dlink.Append(0, 10);
			dlink.ShowAll();
			Console.WriteLine("将 30 插入到表头之后");
			dlink.Append(1, 30);
			dlink.ShowAll();
			Console.WriteLine("将 40 插入到表头之前");
			dlink.Insert(0, 40);
			dlink.ShowAll();
			Console.WriteLine("将 20 插入到第一个位置之前");
			dlink.Insert(1, 20);
			dlink.ShowAll();
			Console.WriteLine("展示第一个:" + dlink.GetFirst());
			Console.WriteLine("删除第一个");
			dlink.DelFirst();
			Console.WriteLine("展示第一个:" + dlink.GetFirst());
			Console.WriteLine("展示最后一个:" + dlink.GetLast());
			Console.WriteLine("删除最后一个");
			dlink.DelLast();
			Console.WriteLine("展示最后一个:" + dlink.GetLast());
			dlink.ShowAll();
			Console.ReadKey();
		}
	}
}
