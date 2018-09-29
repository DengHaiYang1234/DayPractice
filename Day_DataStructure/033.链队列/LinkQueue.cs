using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class LinkQueue<T> : ISeqQueue<T>
    {
        Node<T> prevNode;
        Node<T> endNode;
        int count;

        public LinkQueue()
        {
            prevNode = null;
            endNode = null;
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
            prevNode = null;
            endNode = null;
            count = 0;
        }

        public T Dequeue()
        {
            T value = prevNode.Data;
            if (count == 1)
            {
                prevNode = null;
                endNode = null;
                count = 0;
                return value;
            }

            Node<T> temp = prevNode.Next;
            prevNode = temp;
            count--;
            return value;
        }

        public void Enqueue(T item)
        {
            Node<T> newItem = new Node<T>(item);
            if(endNode == null)
            {
                endNode = newItem;
                prevNode = newItem;
                count++;
                return;
            }
            endNode.Next = newItem;
            endNode = newItem;
            count++;
        }

        public bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public T Peek()
        {
            return prevNode.Data;
        }
    }
}
