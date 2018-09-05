using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
	public class DoubleLinkList<T>
	{
		public Node<T> linkHead;
		int size;


		public DoubleLinkList()
		{
			linkHead = new Node<T>(default(T), null, null);
			linkHead.Prev = linkHead;
			linkHead.Next = linkHead;
			size = 0;
		}

		private Node<T> GetNode(int index)
		{
			if(index < 0 || index >= size)
			{
				throw new IndexOutOfRangeException("错误");
			}

			if(index < size / 2)
			{
				Node<T> temp = linkHead.Next;
				for(int i = 0;i < index;i++)
				{
					temp = temp.Next;
				}
				return temp;
			}

			Node<T> _temp = linkHead.Prev;
			int rIndex = size - index - 1;
			for(int i =0;i < rIndex; i++)
			{
				_temp = _temp.Prev;
			}

			return _temp;
		}

		public T GetFirst() => GetNode(0).Data;
		public T GetLast() => GetNode(size - 1).Data;

		public void Append(int index,T value)
		{
			Node<T> iNode;
			if(index == 0)
			{
				iNode = linkHead;
			}
			else
			{
				index = index - 1;
				if (index < 0)
					throw new Exception("数组越界");
				iNode = GetNode(index);
			}

			Node<T> tNode = new Node<T>(value, iNode, iNode.Next);
			iNode.Next.Prev = tNode;
			iNode.Next = tNode;
			size++;
		}

		public void Insert(int index,T value)
		{
			if (size < 1 || index >= size)
				throw new Exception("没有可插入点或者索引溢出了");

			if(index == 0)
			{
				Append(size, value);
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
			Node<T> iNode = GetNode(index);
			iNode.Prev.Next = iNode.Next;
			iNode.Next.Prev = iNode.Prev;
			size--;
		}

		public void DelFirst() => Del(0);
		public void DelLast() => Del(size - 1);


		public void ShowAll()
		{
			Console.WriteLine("-----------开始展示数据---------------------");
			for(int i = 0; i< size;i++)
			{
				Console.WriteLine("<" + i +  ">" + ":" + GetNode(i).Data);
			}

			Console.WriteLine("-----------数据展示完毕---------------------");

		}
	}
}
