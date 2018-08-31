using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单链表
{
	public interface ILinkListDS<T>
	{
		void Clear();
		int GetLength();
		int Count { get; }
		void Add(T item);
		void Remove(T item);
		void RemoveAt(int index);
		void Insert(int index, T item);
		bool IsExist(T item);
		int IndexOf(T item);
	}
}
