using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单链表
{
	public class Node<T>
	{
		Node<T> next;
		T data;


		public Node()
		{
			Console.WriteLine("Defult Structor!!!!!!!!!!!!!!!!!");
			next = null;
			data = default(T);
		}

		public Node(T value)
		{
			next = null;
			data = value;
		}

		public Node<T> Next
		{
			get { return next; }
			set { next =  value; }
		}

		public T Data
		{
			get { return data; }
			set { data = value; }
		}

	}
}
