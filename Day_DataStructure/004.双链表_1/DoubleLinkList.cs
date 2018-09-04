using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
	//public class DoubleLinkList<T>
	//{
	//	Node<T> head;
	//	int size;
	//	public DoubleLinkList()
	//	{
	//		head = null;
	//		size = 0;
	//	}

	//	public int GerCount() => size;
	//	public int Count => size;
	//	public bool IsEmpty() => (size == 0);

	//	private Node<T> GetNode(int index)
	//	{
	//		if (index > Count || index < 0)
	//		{
	//			Console.WriteLine("索引越界");
	//			return null;
	//		}

	//		if (index == 0)
	//		{
	//			return head;
	//		}
	//		Node<T> temp = head;
	//		if (index < size / 2)
	//		{
	//			for (int i = 0;i < index;i++)
	//			{
	//				temp = temp.Next;
	//			}
	//		}
	//		else
	//		{
	//			int rInex = size - index -1;

	//			if (rInex == 0)
	//			{
	//				temp = temp.Per;
	//			}
	//			else
	//			{
	//				for (int i = 0; i < rInex; i++)
	//				{
	//					temp = temp.Per;
	//				}
	//			}
	//		}
	//		return temp;
	//	}

	//	public T Get(int index) => GetNode(index).Data;
	//	public T GetFirst() => GetNode(0).Data;
	//	public T GetLast() => GetNode(Count - 1).Data;


	//	public void Insert(int index,T t)
	//	{
	//		if (Count < 1 || index > Count)
	//		{
	//			throw new Exception("索引错误");
	//		}

	//		if(index == 0)
	//		{
	//			Append(index, t);
	//		}
	//		else
	//		{
	//			Node<T> iNode = GetNode(index);
	//			Node<T> tNode = new Node<T>(t);
	//			iNode.Per.Next = tNode;
	//			iNode.Per = tNode;
	//			size++;
	//		}
	//	}

	//	public void Append(int index,T t)
	//	{
	//		if (index == 0)
	//		{
	//			Node<T> newNode = new Node<T>(t);
	//			head = newNode;
	//			head.Per = head;
	//			head.Next = head;
	//			size++;
	//			return;
	//		}
	//		if(index == Count - 1)
	//		{

	//		}

	//		index = index - 1;
	//		if (index < 0)
	//			throw new IndexOutOfRangeException("位置不存在");
	//		Node<T> iNode = GetNode(index);
	//		Node<T> tNode = new Node<T>(t);
	//		iNode.Next = tNode;
	//		iNode.Next.Per = iNode;

	//		size++;
	//	}

	//	public void Add(T t)
	//	{
	//		Append(Count - 1, t);
	//	}

	//	public void Del(int index)
	//	{
	//		Node<T> iNode = GetNode(index);
	//		iNode.Per.Next = iNode.Next;
	//		iNode.Next.Per = iNode.Per;
	//		size--;
	//	}

	//	public void DelFirst() => Del(0);
	//	public void DelLast() => Del(Count - 1);

	//	public void ShowAll()
	//	{
	//		Console.WriteLine("-----------------链表数据如下---------------");
	//		for(int i = 0;i < Count;i++)
	//		{
	//			Console.WriteLine("(" + i+ ")=" + Get(i));
	//		}
	//		Console.WriteLine("----------------链表数据展示完毕-------------");
	//	}

	//}

	
	public class DoubleLink<T>
	{
		//表头
		private readonly Node<T> _linkHead;
		//节点个数
		private int _size;
		public DoubleLink()
		{
			_linkHead = new Node<T>(default(T), null, null);//双向链表 表头为空
			_linkHead.Per = _linkHead;
			_linkHead.Next = _linkHead;
			_size = 0;
		}
		public int GetSize() => _size;
		public bool IsEmpty() => (_size == 0);
		//通过索引查找
		private Node<T> GetNode(int index)
		{
			if (index < 0 || index >= _size)
				throw new IndexOutOfRangeException("索引溢出或者链表为空");
			if (index < _size / 2)//正向查找
			{
				Node<T> node = _linkHead.Next;
				for (int i = 0; i < index; i++)
					node = node.Next;
				return node;
			}
			//反向查找
			Node<T> rnode = _linkHead.Per;
			int rindex = _size - index - 1;
			for (int i = 0; i < rindex; i++)
				rnode = rnode.Per;
			return rnode;
		}
		public T Get(int index) => GetNode(index).Data;
		public T GetFirst() => GetNode(0).Data;
		public T GetLast() => GetNode(_size - 1).Data;
		// 将节点插入到第index位置之前
		public void Insert(int index, T t)
		{
			if (_size < 1 || index >= _size)
				throw new Exception("没有可插入的点或者索引溢出了");
			if (index == 0)
				Append(_size, t);
			else
			{
				Node<T> inode = GetNode(index);
				Node <T> tnode = new Node<T>(t, inode.Per, inode);
				inode.Per.Next = tnode;
				inode.Per = tnode;
				_size++;
			}
		}
		//追加到index位置之后
		public void Append(int index, T t)
		{
			Node<T> inode;
			if (index == 0)
				inode = _linkHead;
			else
			{
				index = index - 1;
				if (index < 0)
					throw new IndexOutOfRangeException("位置不存在");
				inode = GetNode(index);
			}
			Node<T> tnode = new Node<T>(t, inode, inode.Next);
			inode.Next.Per = tnode;
			inode.Next = tnode;
			_size++;
		}
		public void Del(int index)
		{
			Node<T> inode = GetNode(index);
			inode.Per.Next = inode.Next;
			inode.Next.Per = inode.Per;
			_size--;
		}
		public void DelFirst() => Del(0);
		public void DelLast() => Del(_size - 1);
		public void ShowAll()
		{
			Console.WriteLine("******************* 链表数据如下 *******************");
			for (int i = 0; i < _size; i++)
				Console.WriteLine("(" + i + ")=" + Get(i));
			Console.WriteLine("******************* 链表数据展示完毕 *******************\n");
		}
	}
}
