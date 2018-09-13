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
			string a = "1a,1s,d,a,s";
			string b = "as";
			string[] ccc = a.Split(',');
			foreach(var i in ccc)
			{
				//Console.WriteLine(i);
			}
			//Console.WriteLine(a.Split(','));

			StringDS c = new StringDS("1,2,3");
			StringDS[] ooo = c.Split(',');
			foreach (var i in ooo)
			{
				Console.WriteLine(i);
			}
			//StringDS d = new StringDS("as");
			//Console.WriteLine(c.Remove(3,2));
		}
	}
}
