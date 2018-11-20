using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class SeqListDS<T> : ISeqListDS<T>
    {
        private T[] arr;
        private int count;

        public SeqListDS(int len)
        {
            arr = new T[len];
            count = 0;
        }

        public SeqListDS() : this(10)
        {
            
        }

        public int Length
        {
            get { return count; }
        }

        public T this[int index]
        {
            get { return arr[index]; }
        }

        public void Add(T item)
        {
            if (count >= arr.Length)
            {
                T[] newArr = new T[count*2];
                for (int i = 0; i < Length; i++)
                {
                    newArr[i] = arr[i];
                }
                newArr[count] = item;
                arr = newArr;
            }
            else
            {
                arr[count] = item;
            }
            count++;
        }

        public void Clear() => count = 0;


        public int GetLength() => count;
        

        public int IndexOf(T item)
        {
            int index = -1;
            for (int i = 0; i < count; i++)
            {
                if (arr[i].Equals(item))
                {
                    index = i;
                }
            }

            return index;
        }

        public void Insert(int index, T item)
        {
            if (count >= arr.Length)
            {
                T[] newArr = new T[count * 2];
                for (int i = 0; i < count; i++)
                {
                    newArr[i] = arr[i];
                }
                arr = newArr;
            }

            for (int i = arr.Length - 1; i > index; i--)
            {
                arr[i] = arr[i - 1];
            }

            arr[index] = item;
            count++;
        }

        public bool IsExist(T item) => IndexOf(item) == -1;
        

        public T Remove(T item)
        {
            int index = IndexOf(item);
            if (index == -1)
            {
                Console.WriteLine("null");
                return default(T);
            }

            T value = arr[index];

            for (int i = index; i < count - 1; i++)
            {
                arr[i] = arr[i + 1];
            }
            count--;
            return value;
        }

        public T RemoveAt(int index)
        {
            T value = arr[index];

            for (int i = index; i < count - 1; i++)
            {
                arr[i] = arr[i + 1];
            }
            count--;

            return value;
        }
    }
}
