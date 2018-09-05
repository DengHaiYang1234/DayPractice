using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
	public class Node<T>
	{
		public T Data { get; set; }
		public Node<T> Prev { get; set; }
		public Node<T> Next { get; set; }

		public Node(T t,Node<T> prev,Node<T> next)
		{
			Data = t;
			Prev = prev;
			Next = next;
		}

	}
}
