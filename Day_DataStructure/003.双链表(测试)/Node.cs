using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 双链表
{
	public class Node<T>
	{
		T data;
		Node<T> perNode;
		Node<T> nextNode;

		public Node()
		{
			data = default(T);
			perNode = null;
			nextNode = null;
		}


		public Node(T value)
		{
			data = value;
			perNode = null;
			nextNode = null;
		}


		public T Data
		{
			get { return data; }
		}

		public Node<T> PerNode
		{ get { return perNode; }
		set { perNode = value; } }

		public Node<T> NextNode
		{
			get { return nextNode; }
			set { nextNode = value; }
		}

	}
}
