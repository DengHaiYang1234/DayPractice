using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
	public class DoubleLinkList<T>
	{
		private Node<T> head;
		private int size;

		public DoubleLinkList()
		{
			head = new Node<T>(default(T), null, null);
			head.Prev = head;
			head.Next = head;
		}

		private Node<T> GetNode(int index)
		{
			if(index < 0 || index >= size)
			{
				throw new IndexOutOfRangeException("索引越界");
			}

			if(index < size / 2)
			{
				Node<T> temp = head.Next;
				for (int i = 0; i < index; i++)
					temp = temp.Next;
				return temp;
			}

			Node<T> _temp = head.Prev;
			int rIndex = size - index - 1;
			for(int i = 0;i < rIndex;i++)
			{
				_temp = _temp.Prev;
			}

			return _temp;
		}

		public T GetFirst() => GetNode(0).Data;
		public T GetLast() => GetNode(size - 1).Data;
		public T Get(int i) => GetNode(i).Data;


		public void Append(int index,T value)
		{
			Node<T> iNode;
			if(index == 0)
			{
				iNode = head;
			}
			else
			{
				index = index - 1;
				if(index < 0 )
				{
					throw new IndexOutOfRangeException("索引越界");
				}
				iNode = GetNode(index);
			}
			Node<T> tNode = new Node<T>(value, iNode, iNode.Next);
			iNode.Next.Prev = tNode;
			iNode.Next = tNode;
			size++;
		}

		public void Insert(int index,T value)
		{
			if (index < 0 || index >= size)
			{
				throw new IndexOutOfRangeException("索引越界");
			}
			
			if(index == 0)
			{
				Append(index, value);
			}
			else
			{
				Node<T> iNode = GetNode(index);
				Node<T> tNode = new Node<T>(value, iNode.Prev, iNode);
				iNode.Prev.Next = tNode;
				iNode.Prev = tNode;
				size++;
			}
		}

		public void Del(int index)
		{
			Node<T> temp = GetNode(index);
			temp.Next.Prev = temp.Prev;
			temp.Prev.Next = temp.Next;
		}

		public void DelFirst() => Del(0);
		public void DelLast() => Del(size - 1);

		public void ShowAll()
		{
			Console.WriteLine("----------------Start------------------");
			for(int i = 0;i < size;i++)
			{
				Console.WriteLine("<" + i + ">:" + Get(i));
			}
			Console.WriteLine("----------------End------------------");
		}

	}
}
