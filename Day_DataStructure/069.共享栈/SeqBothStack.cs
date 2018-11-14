using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    /// <summary>
    /// 顺序栈的两栈共享（双端栈）
    /// </summary>
    public class SeqBothStack<T>
    {
        private T[] data;//数据存储区

        //top[0] 左栈（从data初始位置开始累加）      top[0] 右栈（从data末尾位置开始累减）
        private int[] top = new int[2];

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="size"></param>
        public SeqBothStack(int size)
        {
            data = new T[size];
            top[0] = -1;
            top[1] = size;
        }

        public SeqBothStack() : this(10)
        {
        }

        /// <summary>
        /// 共享栈的最大存储
        /// </summary>
        public int MaxSize
        {
            get { return data.Length; }
        }
        /// <summary>
        /// 共享栈是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => (top[0] == -1) && (top[1] == MaxSize);
        /// <summary>
        /// i栈是否为空
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool IsEmpty(int i)
        {
            bool isEmpty = false;
            switch (i)
            {
                case 0:
                    isEmpty = top[0] == -1 ? true : false;
                    break;
                case 1:
                    isEmpty = top[1] == MaxSize ? true : false;
                    break;
                default:
                    throw new Exception(i + "号栈，不存在");
            }
            return isEmpty;
        }

        /// <summary>
        /// 共享栈是否已满
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            return top[0] + 1 == top[1];
        }
        /// <summary>
        /// 向i栈添加数据
        /// </summary>
        /// <param name="item"></param>
        /// <param name="i"></param>
        public void Push(T item,int i)
        {
            if (IsFull())
            {
                Console.WriteLine("栈已满，无法进栈");
                return;
            }
            switch (i)
            {
                case 0:
                    data[++top[0]] = item;
                    break;
                case 1:
                    data[--top[1]] = item;
                    break;
                default:
                    throw new Exception(i + "号栈，不存在");
            }
        }
        /// <summary>
        /// i栈元素出栈
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public T Pop(int i)
        {
            if (IsEmpty(i)) throw new Exception("栈已空，无法出栈");

            return i == 0 ? data[top[0]--] : data[top[1]++];
        }
        /// <summary>
        /// i栈顶元素
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public T Peek(int i)
        {
            if (IsEmpty(i)) throw new Exception("栈已空，无法出栈");

            return i == 0 ? data[top[0]] : data[top[1]];
        }
        /// <summary>
        /// 共享栈count
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return (top[0] + 1) + (MaxSize - top[1]);
        }
        /// <summary>
        /// i栈count
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int Count(int i)
        {
            if (i < 0 || i > 1) throw new Exception(i + "号栈，不存在");

            return i == 0 ? top[0] + 1 : MaxSize - top[1];
        }
        /// <summary>
        /// 清空共享栈
        /// </summary>
        public void Clear()
        {
            top[0] = -1;
            top[1] = MaxSize;
        }
        /// <summary>
        /// 清空i栈
        /// </summary>
        /// <param name="i"></param>
        public void Clear(int i)
        {
            if (i < 0 || i > 1) throw new Exception(i + "号栈，不存在");
            if (i == 0) top[0] = -1;
            else top[1] = MaxSize;
        }


    }
}
