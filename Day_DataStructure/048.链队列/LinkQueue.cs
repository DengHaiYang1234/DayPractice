using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class LinkQueue<T> : ILinkQueue<T>
    {
        Node<T> head;
        Node<T> end;
        int count;


        public LinkQueue()
        {
            head = null;
            end = null;
            count = 0;
        }


        public int Count
        {
            get
            {
                return count;
            }
        }

        public void Clear()
        {
            head = null;
            end = null;
            count = 0;
        }

        public T Dequeue()
        {
            T value = head.Data;
            head = head.Next;
            count--;
            return value;
        }

        public void Enqueue(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if(head == null)
            {
                end = newNode;
                head = end;
            }
            else
            {
                end.Next = newNode;
                end = newNode;
            }
            count++;
        }

        public bool IsEmpty() => head == null;
        

        public T Peek()
        {
            return head.Data;
        }
    }
}
