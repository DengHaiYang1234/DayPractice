using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
	public class LinkStackDS<T> : ILinkStack<T>
	{
		Node<T> head;
		Node<T> tail;
		int count;

		public LinkStackDS()
		{
			head = null;
			tail = null;
			count = 0;
		}


		public int Count
		{
			get
			{
				return count;
			}
		}

		public void Clear() => head = tail = null;
		

		public bool Contains(T item)
		{
			bool isHave = false;
			Node<T> temp = head;
			if(temp.Data.Equals(item))
			{
				return true;
			}
			else
			{
				while (temp.Next != null)
				{
					if (temp.Data.Equals(item))
					{
						isHave = true;
						break;
					}
					temp = temp.Next;
				}
			}
			return isHave;
		}

		public T Peek()
		{
			return tail.Data;
		}

		public T Pop()
		{
			T value = tail.Data;

			Node<T> temp = head;
			for(int i = 1;i < count - 1;i++)
			{
				temp = temp.Next;
			}

			temp.Next = null;
			tail = temp;
			count--;
			return value;
		}

		public void Push(T item)
		{
			Node<T> newNode = new Node<T>(item);
			if(head == null)
			{
				head = newNode;
				count++;
				return;
			}
			Node<T> temp = head;
			while(temp.Next != null)
			{
				temp = temp.Next;
			}

			temp.Next = newNode;
			tail = temp.Next;
			count++;
		}
	}
}
