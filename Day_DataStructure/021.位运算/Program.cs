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
            int i10 = 68;
            int i16 = 0x2A;

            //Console.WriteLine("实例一：");
            //Console.Write("10进制【68】转2、8、16进制结果：{0},{1},{2}\n",Convert.ToString(i10,2),Convert.ToString(i10,8),Convert.ToString(i10,16));

            //Console.Write("16进制【0x2A】转2、8、10进制结果：{0},{1},{2}\n", Convert.ToString(i16, 2), Convert.ToString(i16, 8), Convert.ToString(i16, 10));

            //int a = 10;
            //int b = 20;
            //Swap(ref a,ref b);

            //Console.WriteLine(4 | 8); //除了0|0结果是0外，其它运算结果的都是1

            //Console.WriteLine(4 & 8);//除了1&1结果是1外，其它运算结果的都是0


            //int a = 4;
            //int b = 8;

            //Console.WriteLine(4 ^ 8);

            //string i10a = Convert.ToString(a, 2);
            //string i10b = Convert.ToString(b, 2);

            Console.WriteLine(302 / 2 );
            Console.WriteLine(302 % 2);
        }

        static void Swap(ref int a,ref int b)
        {
            a ^= b;
            Console.WriteLine(a);
            b ^= a;
            Console.WriteLine(b);
            a ^= b;
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}
