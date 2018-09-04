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
			DoubleLinkList<int> dlink = new DoubleLinkList<int>();// 创建双向链表

			Console.WriteLine("将 20 插入到表头之后");
			dlink.Append(0, 10);
			dlink.ShowAll();
			Console.WriteLine("将 40 插入到表头之后");
			dlink.Append(1, 30);
			dlink.ShowAll();
		}
	}
}
