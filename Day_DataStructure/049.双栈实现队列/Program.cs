using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class Program
    {

        private  static Stack<int> stack_1 = new Stack<int>();
        private  static Stack<int> stack_2 = new Stack<int>();

        static void Main(string[] args)
        {
            Enqueue(stack_1, 1);
            Enqueue(stack_1, 2);
            Enqueue(stack_1, 3);
            Enqueue(stack_1, 4);
            Enqueue(stack_1, 5);

            DeQueue(stack_1, stack_2);
            DeQueue(stack_1, stack_2);
            DeQueue(stack_1, stack_2);
            DeQueue(stack_1, stack_2);
            DeQueue(stack_1, stack_2);
        }


        static void Enqueue(Stack<int> stack,int item)
        {
            stack.Push(item);
            Console.WriteLine("入栈：" + item);
        }


        static void DeQueue(Stack<int> stack1, Stack<int> stack2)
        {
            while (stack1.Count > 0)
            {
                int temp = stack1.Peek();
                stack1.Pop();
                stack2.Push(temp);
            }

            int value = stack2.Peek();
            stack2.Pop();
            Console.WriteLine("出栈:" + value);
        }
    }
}
