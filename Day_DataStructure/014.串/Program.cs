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
			string a = "1a1sdas";
			string b = "as";
			Console.WriteLine(a.Remove(3,2));

			StringDS c = new StringDS("1a1sdas");
			//StringDS d = new StringDS("as");
			Console.WriteLine(c.Remove(3,2));
		}
	}
}
