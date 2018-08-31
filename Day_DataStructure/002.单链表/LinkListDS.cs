using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单链表
{
	public class LinkListDS<T> : ILinkListDS<T>
	{
		Node<T> head;
		
		public LinkListDS()
		{
			head = null;  //引用不指向任何一个对象
		}

		public T this[int index]
		{
			get
			{
				T data = default(T);
				if (head == null || index > Count || index < 0)
				{
					Console.WriteLine("索引有误或链表为空");
				}
				else
				{
					if(index == 0)
					{
						return head.Data;
					}
					else
					{
						Node<T> temp = head;
						for (int i = 0; i < index; i++)
						{
							temp = temp.Next;
						}

						data = temp.Data;
					}
				}
				return data;
			}
		}

		public int Count
		{
			get
			{
				if(head == null)
				{
					return 0;
				}

				int len = 1;
				Node<T> temp = head;
				while(temp.Next != null)
				{
					len++;
					temp = temp.Next;
				}
				return len;
			}
		}

		public void Add(T item)
		{
			Node<T> newNode = new Node<T>(item);
			if(head == null)
			{
				head = newNode;
				return;
			}

			Node<T> temp = head;
			while(temp.Next != null)
			{
				temp = temp.Next;
			}

			temp.Next = newNode;
		}

		public void Clear()
		{
			head = null;
		}

		public int GetLength()
		{
			Console.WriteLine("count:" + Count);
			return Count;
		}

		public int IndexOf(T item)
		{
			int index = 0;
			if(head == null)
			{
				Console.WriteLine("链表为空");
				return -1;
			}

			Node<T> temp = head;
			while(temp.Next != null)
			{
				if(temp.Data.Equals(item))
				{
					break;
				}

				index++;
				temp = temp.Next;
			}

			return index;

		}

		public void Insert(int index, T item)
		{
			if(head == null || index > Count || index <0)
			{
				Console.WriteLine("索引有误或链表为空");
				return;
			}

			Node<T> temp = head;
			Node<T> newNode = new Node<T>(item);
			for(int i = 1; i < index;i++)
			{
				temp = temp.Next;
			}

			Node<T> leftNode = temp;
			Node<T> rightNode = temp.Next;
			leftNode.Next = newNode;
			newNode.Next = rightNode;
		}

		public bool IsExist(T item)
		{
			bool isExist = false;
			Node<T> temp = head;
			while(temp.Next != null)
			{
				if(temp.Data.Equals(item))
				{
					isExist = true;
					break;
				}
				temp = temp.Next;
			}
			return isExist;
		}

		public void Remove(T item)
		{
			if(!IsExist(item))
			{
				Console.WriteLine("不存在该元素");
				return;
			}

			int index = IndexOf(item);

			Node<T> temp = head;
			for(int i = 1;i < index;i++)
			{
				temp = temp.Next;
			}
			temp.Next = temp.Next.Next;
		}

		public void RemoveAt(int index)
		{
			if (head == null || index > Count || index < 0)
			{
				Console.WriteLine("索引有误或链表为空");
				return;
			}

			Node<T> temp = head;
			for(int i = 1; i < index;i++)
			{
				temp = temp.Next;
			}

			temp.Next = temp.Next.Next;

		}
	}
}
