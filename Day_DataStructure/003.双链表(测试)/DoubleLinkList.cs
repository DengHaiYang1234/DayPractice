using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 双链表
{
	public class DoubleLinkList<T> : IDoublieLinkList<T>
	{
		Node<T> head;

		public DoubleLinkList()
		{
			head = null;
		}

		public T this[int index]
		{
			get
			{
				if (index > Count && index <0 || head == null)
				{
					Console.WriteLine("索引或链表错误");
					return default(T);
				}


				if(index == 0)
				{
					return head.Data;
				}

				Node<T> temp = head;
				for(int i = 0;i < index;i++)
				{
					temp = temp.NextNode;
				}

				return temp.Data;
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
				int index = 1;
				Node<T> temp = head;
				while(temp.NextNode != null)
				{
					index++;
					temp = temp.NextNode;
				}
				return index;
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
			while(temp.NextNode!=null)
			{
				temp = temp.NextNode;
			}
			temp.NextNode = newNode;
			temp.NextNode.PerNode = temp;
			temp.PerNode = newNode;
			newNode.NextNode = temp;
		}

		public void Clear()
		{
			head = null;
		}

		public int GetLength()
		{
			return Count;
		}

		public int IndexOf(T item)
		{
			if(head == null)
			{
				Console.WriteLine("链表为空");
				return -1;
			}

			if(!IsExist(item))
			{
				Console.WriteLine("不存在该元素");
				return -1;
			}

			Node<T> temp = head;
			int index = 0;
			if (temp.NextNode == null && temp.Data.Equals(item))
			{
				return index;
			}

			while (temp.NextNode != null)
			{
				if (temp.Data.Equals(item))
				{
					break;
				}
				index++;
				temp = temp.NextNode;
			}
			return index;
		}
		
		public void Insert(int index, T item)
		{
			if(index > Count || index < 0 || head == null)
			{
				Console.WriteLine("索引或链表错误");
				return;
			}

			Node<T> newNode = new Node<T>(item);
			Node<T> temp = head;
			for(int i = 1; i < index;i++)
			{
				temp = temp.NextNode;
			}

			Node<T> leftNode = temp;
			Node<T> rightNode = temp.NextNode;
			leftNode.NextNode = newNode;
			leftNode.NextNode.PerNode = leftNode;
			newNode.NextNode = rightNode;
			rightNode.PerNode = newNode;
		}

		public bool IsExist(T item)
		{
			if(Count == 1)
			{
				return head.Data.Equals(item);
			}

			bool isHave = false;
			Node<T> temp = head;
			while(temp.NextNode != null)
			{
				if(temp.Data.Equals(item))
				{
					isHave = true;
					break;
				}
				temp = temp.NextNode;
			}

			return isHave;
		}

		public void Remove(T item)
		{
			if(head == null)
			{
				Console.WriteLine("链表为空");
				return;
			}

			Node<T> temp = head;
			int index = IndexOf(item);

			if(index ==0)
			{
				head = head.NextNode;
				return;
			}

			for(int i = 0;i < index -1 ;i++)
			{
				temp = temp.NextNode;
			}
			Node<T> leftNode = temp;
			Node<T> rightNode = temp.NextNode;

			leftNode.NextNode = rightNode.NextNode;
			leftNode.NextNode.PerNode = leftNode;
		}

		public void RemoveAt(int index)
		{
			throw new NotImplementedException();
		}
	}
}
