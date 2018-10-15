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
            StringDS a = new StringDS("123234456");
            StringDS b = new StringDS("12232344");
            //Console.WriteLine("结果:" + a.IndexOf(b));

            //StringDS c = new StringDS("122323442");
            
            //Console.WriteLine(c.Remove(3));

            string ad = "12,23a,sd";
            //Console.WriteLine(ad.Substring(3));

            string[] str =  ad.Split(',');
            for(int i = 0; i< str.Length;i++)
            {
                //Console.WriteLine(str[i]);
            }


            StringDS asd = new StringDS("12qe,wqwe,2df,gdfg,3a,sd,wetert,ertert,ert");
            //string ad = "12,23a,sd";
            //Console.WriteLine(ad.Substring(3));

            StringDS[] str1 = asd.Split(',');
            for (int i = 0; i < str1.Length; i++)
            {
                Console.WriteLine(str1[i]);
            }

            //StringDS c = new StringDS("1223asd");
            //Console.WriteLine(c.SubString(3));
        }
    }
}
