using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
	public class SeqQueue<T> : IQueueDS<T>
	{
		T[] arr;
		int headIndex;
		int endIndex;
		int count;
		public SeqQueue(int size)
		{
			arr = new T[size];
			headIndex = -1;
			endIndex = -1;
			count = 0;
		}


		public SeqQueue() : this(3)
		{

		}


		public int Count
		{
			get
			{
				return count;
			}
		}

		public void Clear() => count = 0;
		
		public bool Contians(T item)
		{
			bool isHave = false;
			for(int i = 0;i < arr.Length;i++)
			{
				if (arr[i].Equals(item))
					isHave = true;
			}

			return isHave;
		}

		public T Dequeue()
		{
			if(headIndex == count - 1)
			{
				headIndex = -1;
			}

			T value = arr[headIndex + 1];
			headIndex++;
			count--;
			return value;
		}

		public void Enqueue(T item)
		{
			if(endIndex == arr.Length - 1)
			{
				endIndex = -1;
			}

			arr[endIndex + 1] = item;
			endIndex++;
			if(count < arr.Length)
			{
				count++;
			}
			
		}

		public T Peek()
		{
			return arr[headIndex + 1];
		}

		public bool IsEmpty() => count == 0;
		
	}
}
