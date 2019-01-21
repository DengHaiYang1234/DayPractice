using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
两种思路：
1.若固定的先Push后Pop，那么可以向将stack_1的元素全部Pop并Push进stack_2。
2.（动态添加）若不固定，那么就先获取到stack_1最后一个元素，其余元素全部Pop至stack_2中，等最后一个元素Pop完成，再将stack_2的元素全部添加至stack_1。
*/
namespace project
{
    class Program
    {
        private static Stack<int> stack_1 = new Stack<int>();
        private static Stack<int> stack_2 = new Stack<int>();

        static void Main(string[] args)
        {
            Enqueue(1);
            Enqueue(2);
            Enqueue(3);
            Enqueue(4);
            Enqueue(5);
            Console.WriteLine("=============================");
            Dequeue();
            Dequeue();
            Dequeue();
            Console.WriteLine("============================");
            Enqueue(6);
            Console.WriteLine("============================");
            Dequeue();
            Enqueue(7);
            Enqueue(8);
            Enqueue(9);
            Dequeue();
            Dequeue();
            Dequeue();
            Dequeue();
            Dequeue();
        }

        static void Enqueue(int value)
        {
            stack_1.Push(value);
            Console.WriteLine("Enqueue:" + value);
        }

        static int Dequeue()
        {
            int value = -1;
            #region 动态添加
            //while (stack_1.Count > 1)
            //{
            //    stack_2.Push(stack_1.Pop());
            //}

            //value = stack_1.Pop();
            //Console.WriteLine("Dequeue:" + value);


            //while (stack_2.Count > 0)
            //{
            //    stack_1.Push(stack_2.Pop());
            //}
            #endregion

            #region 非动态添加
            while (stack_1.Count > 1)
            {
                stack_2.Push(stack_1.Pop());
            }

            if (stack_2.Count > 0)
            {
                value = stack_2.Pop();
            }

            #endregion

            return value;
        }
    }
}
