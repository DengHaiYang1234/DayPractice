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
			string a = "1a34523";
			string b = "as";

			Console.WriteLine(a.Substring(3));

			StringDS c = new StringDS("1a34523");
			Console.WriteLine(c.Substring(3));
			//string[] ccc = a.Split(',');
			//foreach(var i in ccc)
			//{
			//	//Console.WriteLine(i);
			//}
			//Console.WriteLine(a.Split(','));

			//StringDS c = new StringDS("123,222,344,334,555,666,777,888,9");
			//StringDS[] ooo = c.Split(',');
			//foreach (var i in ooo)
			//{
			//	Console.WriteLine(i);
			//}
			//StringDS d = new StringDS("as");
			//Console.WriteLine(c.Remove(3,2));
		}
	}
}
