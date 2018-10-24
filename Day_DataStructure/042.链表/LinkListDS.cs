using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class LinkListDS<T> : ILinkListDS<T>
    {
        Node<T> head;

        public LinkListDS()
        {
            head = null;
        }


        public int Length
        {
            get
            {
                return GetLength();
            }
        }

        public T this[int index]
        {
            get
            {
                T value = default(T);
                Node<T> node = GetNode(index);
                if(node != null)
                {
                    value = node.Data;
                }
                return value;
            }
        }

        public void Add(T item)
        {
            Node<T> newNode = new Node<T>(item);
            Node<T> temp = head;

            if(head == null)
            {
                head = newNode;
            }
            else
            {
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = newNode;
            }
        }

        public void Clear() => head = null;

        public int GetLength()
        {
            Node<T> temp = head;
            int index = 0;
            while(temp != null)
            {
                index++;
                temp = temp.Next;
            }

            return index;
        }

        public int IndexOf(T item)
        {
            Node<T> temp = head;
            int index = -1;
            while(temp != null)
            {
                index++;
                if (temp.Data.Equals(item))
                    break;
                temp = temp.Next;
            }
            return index;
        }

        public Node<T> GetNode(T item)
        {
            Node<T> temp = head;
            while (temp != null)
            {
                if (temp.Data.Equals(item))
                    break;
                temp = temp.Next;
            }
            return temp;
        }

        public Node<T> GetNode(int index)
        {
            Node<T> temp = head;
            int idx = 0;
            while (temp != null)
            {
                if (idx == index)
                    break;
                idx++;
                temp = temp.Next;
            }
            return temp;
        }

        //之前
        public void Insert(int index, T item)
        {
            if(index > Length || index < 0)
            {
                Console.WriteLine("Insert 越界");
            }
            else
            {
                Node<T> newNode = new Node<T>(item);
                if(index == 0)
                {
                    newNode.Next = head;
                    head = newNode;
                }
                else
                {
                    Node<T> temp = head;
                    for(int i = 1; i < index;i++)
                    {
                        temp = temp.Next;
                    }

                    Node<T> pre = temp;
                    Node<T> post = temp.Next;
                    temp.Next = newNode;
                    newNode.Next = post;
                }
            }
        }

        //之后
        public void Append(int index, T item)
        {
            if (index > Length || index < 0)
            {
                Console.WriteLine("越界");
            }
            else
            {
                Node<T> newNode = new Node<T>(item);

                Node<T> currNode = GetNode(index);
                Node<T> postNode = currNode.Next;
                currNode.Next = newNode;
                newNode.Next = postNode;

                //if (index == 0)
                //{
                //    Node<T> temp = head;
                //    Node<T> post = temp.Next;
                //    temp.Next = newNode;
                //    newNode.Next = post;
                //}
                //else
                //{
                //    Node<T> currNode = GetNode(item);
                //    Node<T> postNode = currNode.Next;
                //    currNode.Next = newNode;
                //    newNode.Next = postNode;
                //}
            }
        }

        public bool IsExist(T item) => head == null;
        

        public T Remove(T item)
        {
            int index = IndexOf(item);
            T value = default(T);
            if (index < 0 || index >= Length)
            {
                Console.WriteLine("越界");
            }
            else
            {
                if(index == 0)
                {
                    value = head.Data;
                    head = head.Next;
                }
                else
                {
                    value = GetNode(item).Data;
                    Node<T> temp = head;
                    for (int i = 1; i < index; i++)
                    {
                        temp = temp.Next;
                    }

                    Node<T> pre = temp;
                    Node<T> post = temp.Next.Next;
                    pre.Next = post;
                }
            }
            return value;
        }

        public T RemoveAt(int index)
        {
            T value = default(T);
            if (index < 0 || index >= Length)
            {
                Console.WriteLine("越界");
            }
            else
            {
                if (index == 0)
                {
                    value = head.Data;
                    head = head.Next;
                }
                else
                {
                    Node<T> temp = head;
                    for (int i = 1; i < index; i++)
                    {
                        temp = temp.Next;
                    }
                    value = temp.Next.Data;
                    Node<T> pre = temp;
                    Node<T> post = temp.Next.Next;
                    pre.Next = post;
                }
            }
            return value;
        }


    }
}
