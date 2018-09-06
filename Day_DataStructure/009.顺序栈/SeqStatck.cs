using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
	public class SeqStatck<T> : ISeqStack<T>
	{
		T[] arr;
		int top;

		public int Count
		{
			get
			{
				int len = top;
				len = len + 1;
				return len;
			}
		}


		public SeqStatck(int size)
		{
			arr = new T[size];
			top = -1;
		}

		public SeqStatck() : this(10)
		{

		}

		public void Clear() => top = -1;
		
		public bool Contains(T item)
		{
			bool isHave = false;

			for(int i = 0;i < arr.Length;i++)
			{
				if(arr[i].Equals(item))
				{
					isHave = true;
				}
			}
			return isHave;
		}

		public T Peek()
		{
			return arr[top];
		}

		public T Pop()
		{
			T value = arr[top];
			top--;
			Console.WriteLine("Top:" + top);
			return value;
		}

		public void Push(T item)
		{
			if(top < arr.Length)
			{
				arr[top + 1] = item;
				top++;
			}
			else
			{
				throw new Exception("栈已满");
			}
		}
	}
}
