using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
	public class DoubleLinkList<T>
	{
		private readonly Node<T> linkHead;
		private int size;

		public DoubleLinkList()
		{
			linkHead = new Node<T>(default(T), null, null);
			linkHead.Prev = linkHead;
			linkHead.Next = linkHead;
			size = 0;
		}

		public int GetSize() => size;
		public bool IsEmpty() => (size == 0);

		private Node<T> GetNode(int index)
		{
			if(index < 0 || index >= size)
			{
				throw new IndexOutOfRangeException("索引溢出或者链表为空");
			}
			if(index < size / 2)
			{
				Node<T> node = linkHead.Next;
				for(int i = 0;i < index;i++)
				{
					node = node.Next;  //拿到索引位置的node
				}

				return node;
			}

			Node<T> rNode = linkHead.Prev;
			int rIndex = size - index - 1;
			for(int i = 0;i< rIndex;i++)
			{
				rNode = rNode.Prev;
			}

			return rNode;
		}


		public T Get(int index) => GetNode(index).Data;
		public T GetFirst() => GetNode(0).Data;
		public T GetLast() => GetNode(size - 1).Data;

		public void Insert(int index, T t)
		{
			if (size < 1 || index >= size)
			{
				throw new Exception("没有可插入的点或者索引溢出了");
			}
			if(index == 0)
			{
				Append(size, t);
			}
			else
			{
				Node<T> iNode = GetNode(index);
				Node<T> tNode = new Node<T>(t, iNode.Prev, iNode);
				iNode.Prev.Next = tNode;
				iNode.Prev = tNode;
				size++;
			}
		}

		public void Append(int index,T t)
		{
			Node<T> iNode;
			if(index ==0)
			{
				iNode = linkHead;
			}
			else
			{
				index = index - 1;
				if(index < 0)
				{
					throw new IndexOutOfRangeException("位置不存在");
				}
				iNode = GetNode(index);
			}

			Node<T> tNode = new Node<T>(t, iNode, iNode.Next); //tNode prev指向iNode的前一个  tNode指向iNode的后一个
			iNode.Next.Prev = tNode;
			iNode.Next = tNode;
			size++;

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
			Console.WriteLine("-------------------链表数据如下----------------------");
			for(int i = 0;i< size;i++)
			{
				Console.WriteLine("(" + i + ")=" + Get(i));
			}
			Console.WriteLine("-------------------链表数据展示完毕----------------------");
		}

	}
}
