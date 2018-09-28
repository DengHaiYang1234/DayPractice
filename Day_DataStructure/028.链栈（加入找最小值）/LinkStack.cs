using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class LinkStack : ILinkStack
    {
        Node<int> top;
        Node<int> min;
        int len;

        public LinkStack()
        {
            top = null;
            min = null;
            len = 0;
        }

        public int Count
        {
            get
            {
                return len;
            }
        }

        public void Clear()
        {
            top = null;
            len = 0;
        }
        

        public int Peek()
        {
            int value = top.Data;
            return value;
        }

        public int Pop()
        {
            int value = top.Data;
                
            //若当前最小节点被删除，那么最小值就往后移一位
            if(top.Data == min.Data)
            {
                Node<int> _temp = min.Next;
                min = _temp;
            }

            Node<int> temp = top.Next;
            top = temp;
            len--;
            return value;
        }

        public void Push(int item)
        {
            Node<int> newItem = new Node<int>(item);
            Node<int> temp = newItem;
            if(top == null)
            {
                top = newItem;
                min = newItem;
                len++;
                return;
            }
            //新的指向原来的节点。那么新节点就是最top的节点
            newItem.Next = top;
            top = newItem;
            len++;

            //这一步的作用主要是让当前min链表的头结点始终保持最小的那个值
            //若新添加的元素比当前最小元素大，那么就添加在当前最小元素的Next
            if (temp.Data > min.Data)
            {
                min.Next = temp;
            }
            else//若新添加的元素比当前最小元素小，那么就添加在当前最小元素的前面
            {
                temp.Next = min;
                min = temp;
            }

        }

        public int Min()
        {
            if(Count == 0)
            {
                min = null;
                Console.WriteLine("栈为空");
                return -1;
            }
            return min.Data;
        }
    }
}
