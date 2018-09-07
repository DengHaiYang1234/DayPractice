using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
	public class LinkQueue<T> : ILinkQueue<T>
	{
		Node<T> front;
		Node<T> rear;
		int count;


		public LinkQueue()
		{
			front = null;
			rear = null;
			count = 0;
		}


		public int Count
		{
			get
			{
				return count;
			}
		}

		public void Clear() => front = rear = null;
		

		public bool Contians(T item)
		{
			throw new NotImplementedException();
		}

		public T Dequeue()
		{
			T value = front.Data;
			if (count == 1)
			{
				front = null;
				rear = null;
				count = 0;
				return value;
			}

			front = front.Next;
			count--;
			return value;
		}

		public void Enqueue(T item)
		{
			Node<T> newNode = new Node<T>(item);
			if(front == null)
			{
				rear = newNode;
				front = newNode;
				count++;
				return;
			}

			//Node<T> temp = rear;
			//while(temp.Next != null)
			//{
			//	temp = temp.Next;
			//}

			//temp.Next = newNode;

			rear.Next = newNode;
			rear = rear.Next;

			count++;
		}

		public bool IsEmpty() => front == null;


		public T Peek() => front.Data;
	}
}
