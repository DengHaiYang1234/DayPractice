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
		int top;

		public LinkStackDS()
		{
			head = null;
			top = 0;
		}


		public int Count
		{
			get
			{
				return top;
			}
		}

		public void Clear()
		{
			head = null;
		}

		public bool Contains(T item)
		{
			throw new NotImplementedException();
		}

		public T Peek()
		{
			return head.Data;
		}

		public T Pop()
		{
			T value = head.Data;
			Node<T> temp = head.Next;
			head = temp;
			top--;
			return value;
		}

		public void Push(T item)
		{
			Node<T> newNode = new Node<T>(item);
			if(head == null)
			{
				head = newNode;
				top++;
				return;
			}

			newNode.Next = head;
			head = newNode;
			

			top++;
		}
	}
}
