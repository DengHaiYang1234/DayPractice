using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_顺序表
{
	public class SeqList<T> : IListDs<T>
	{
		T[] arr;
		int count;

		public SeqList(int len)
		{
			arr = new T[len];
			count = 0;
		}

		public SeqList() : this(1)
		{

		}

		public T this[int index]
		{
			get { return arr[index]; }
		}
	
		public int Legth
		{
			get
			{
				return count;
			}
		}

		public void Add(T item)
		{
			if(count >= arr.Length)
			{
				T[] newArr = new T[count * 2];
				for(int i =0;i < arr.Length;i++)
				{
					newArr[i] = arr[i];
				}
				newArr[count] = item;
				arr = newArr;
				count++;
				return;
			}
			arr[count] = item;
			count++;
		}

		public void Clear()
		{
			count = 0;
		}

		public int GetLength()
		{
			return count;
		}

		public int IndexOf(T item)
		{
			int index = -1;
			for(int i =0; i < count;i++)
			{
				if (arr[i].Equals(item))
					index = i;
			}

			return index;
		}

		public void Insert(int index, T item)
		{
			if(count >= arr.Length)
			{
				T[] newArr = new T[count * 2];
				for(int i =0;i < arr.Length;i++)
				{
					newArr[i] = arr[i];
				}
				arr = newArr;
			}

			for (int i = count - 1; i >= index; i--)
			{
				arr[i + 1] = arr[i];
			}

			arr[index] = item;
			count++;
		}

		public bool IsExist(T item)
		{
			bool isExist = false;
			for(int i = 0; i < count;i++)
			{
				if (arr[i].Equals(item))
					isExist = true;
			}

			return isExist;
		}

		public void Remove(T item)
		{
			if(count == 0)
			{
				Console.WriteLine("数组为空");
				return;
			}

			if(!IsExist(item))
			{
				Console.WriteLine("不包含该元素");
				return;
			}

			int index = IndexOf(item);

			for(int i = index;i < count - 1;i++)
			{
				arr[i] = arr[i + 1];
			}
			count--;
		}

		public void RemoveAt(int index)
		{
			if(index > count || index < 0)
			{
				Console.WriteLine("数组超界限");
				return;
			}

			for (int i = index; i < count + 1; i++)
			{
				arr[i] = arr[i + 1];
			}
			count--;
		}
	}
}
