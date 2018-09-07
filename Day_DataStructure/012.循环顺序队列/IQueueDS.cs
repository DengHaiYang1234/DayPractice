using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
	public interface IQueueDS<T>
	{
		int Count { get; }
		void Clear();
		bool Contians(T item);
		void Enqueue(T item);
		T Dequeue();
		T Peek();
		bool IsEmpty();
	}
}
