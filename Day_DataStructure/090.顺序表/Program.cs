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
            SeqListDS<int> a = new SeqListDS<int>();
            a.Add(1);
            a.Add(18);
            a.Add(89);
            a.Remove(18);
            a.Add(55);
            a.Add(56);
            a.Add(57);
            a.Add(58);
            a.Insert(2, 6666);
            Console.WriteLine("index:" + a.IndexOf(55));

            Console.WriteLine("---------------SeqList-------------");
            for (int i = 0; i < a.GetLength(); i++)
                Console.WriteLine(a[i]);
        }
    }
}
