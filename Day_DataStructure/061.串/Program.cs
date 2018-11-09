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
            #region Compare
            //StringDS s1 = new StringDS("123");
            //StringDS s2 = new StringDS("123123");
            //Console.WriteLine("StringDS:" + StringDS.Compare(s1, s2));

            //string ss1 = "123";
            //string ss2 = "123123";
            //Console.WriteLine("String:" + string.Compare(ss1, ss2));
            #endregion
            #region IndexOf
            //StringDS s1 = new StringDS("ssss123123as");
            //StringDS s2 = new StringDS("123");
            //Console.WriteLine("StringDS:" + s1.IndexOf(s2));

            //string ss1 = "ssss123123as";
            //string ss2 = "123";
            //Console.WriteLine("String:" + ss1.IndexOf(ss2));
            #endregion
            #region Remove
            //StringDS s1 = new StringDS("ssssqwe123fg");
            ////Console.WriteLine("StringDS:" + s1.Remove(4));
            //Console.WriteLine("StringDS:" + s1.Remove(4,6));
            //string ss1 = "ssssqwe123fg";
            ////Console.WriteLine("String:" + ss1.Remove(4));
            //Console.WriteLine("String:" + ss1.Remove(4, 6));
            #endregion
            #region SubString
            //StringDS s1 = new StringDS("ssssqwe123fg");
            ////Console.WriteLine("StringDS:" + s1.Substring(10));
            //Console.WriteLine("StringDS:" + s1.Substring(1, 6));
            //string ss1 = "ssssqwe123fg";
            ////Console.WriteLine("String:" + ss1.Substring(10));
            //Console.WriteLine("String:" + ss1.Substring(1, 6));
            #endregion
            #region Split
            StringDS s1 = new StringDS("ssssqwtyu67677678,");
            StringDS[] dss = s1.Split(',');

            foreach (var ds in dss)
            {
                Console.WriteLine(ds);
            }
            Console.WriteLine("------------------------");
            string ss1 = "ssssqwtyu67677678,";
            string[] sss = ss1.Split(',');
            foreach (var ds in sss)
            {
                Console.WriteLine(ds);
            }
            #endregion
        }
    }
}
