using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
	class Node<T>
	{
		Node<T> per;
		Node<T> next;
		T data;


		public Node(T val,Node<T> pre,Node<T> next)
		{
			data = val;
			this.per = pre;
			this.next = next;
		}

		public Node<T> Per
		{
			get { return per; }
			set { per = value; }
		}

		public Node<T> Next
		{
			get { return next; }
			set { next = value; }
		}

		public T Data
		{
			get { return data; }
		}

	}
}
