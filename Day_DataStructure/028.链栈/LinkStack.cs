using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class LinkStack<T> : ILinkStack<T>
    {
        Node<T> top;
        int len;

        public LinkStack()
        {
            top = null;
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
        

        public T Peek()
        {
            T value = top.Data;
            return value;
        }

        public T Pop()
        {
            T value = top.Data;
            Node<T> temp = top.Next;
            top = temp;
            len--;
            return value;
        }

        public void Push(T item)
        {
            Node<T> newItem = new Node<T>(item);
            if(top == null)
            {
                top = newItem;
                len++;
                return;
            }
            //新的指向原来的节点。那么新节点就是最top的节点
            newItem.Next = top;
            top = newItem;
            len++;
        }
    }
}
