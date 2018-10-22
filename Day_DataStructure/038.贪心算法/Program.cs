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
            int[] values = { 1, 2, 5, 10, 20, 50, 100 };
            int[] counts = { 3, 1, 2, 1, 1, 3, 5 };
            int[] num = Change(442, values, counts);
            Print(num,values);
        }

        static int[] Change(int money,int[] value,int[] counts)
        {
            int[] result = new int[value.Length];

            for(int i = value.Length - 1;i >= 0;i--)
            {
                int num = 0;
                Console.WriteLine("money / value[i]:" + (money / value[i]));
                int c = Min(money / value[i], counts[i]);
                money = money - c * value[i];
                num += c;
                result[i] = num;
            }
            return result;
        }

        /// <summary>
        /// 获取各面值货币的数量
        /// </summary>
        /// <param name="i"></param>  理论需要
        /// <param name="j"></param>  实际拥有
        /// <returns></returns>
        static int Min(int i,int j)
        {
            return i > j ? j : i;
        }


        static void Print(int[] num,int[] values)
        {
            for(int i = 0;i<values.Length;i++)
            {
                if(num[i] !=0)
                {
                    Console.WriteLine("需要面额为：" + values[i] + "的人民币" + num[i] + "张");
                }
            }
        }
        
    }
}
