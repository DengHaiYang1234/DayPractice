using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_顺序表
{
	public interface IListDs<T>
	{
		void Clear();
		int GetLength();
		int Legth { get; }
		void Add(T item);
		void Remove(T item);
		void RemoveAt(int index);
		void Insert(int index, T item);
		bool IsExist(T item);
		int IndexOf(T item);
	}
}
