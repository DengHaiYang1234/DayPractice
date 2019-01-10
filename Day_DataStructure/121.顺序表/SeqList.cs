using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class SeqList<T> : ISeqList<T>
    {
        private T[] arr;
        private int count = 0;

        public T this[int index]
        {
            get { return arr[index]; }
        }

        public SeqList(int len)
        {
            arr = new T[len];
        }

        public SeqList() : this(10)
        {
            
        }

        public int Length
        {
            get { return count; }
        }

        public void Add(T item)
        {
            if (count >= arr.Length)
            {
                T[] newArr = new T[count*2];
                for (int i = 0; i < count; i++)
                    newArr[i] = arr[i];
                newArr[count] = item;
                arr = newArr;
            }
            else
                arr[count] = item;
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
                    break;
                }
            }
            return index;
        }

        public void Insert(int index, T item)
        {
            if (count >= arr.Length)
            {
                T[] newArr = new T[count*2];
                for (int i = 0; i < count; i++)
                    newArr[i] = arr[i];

                arr = newArr;
            }

            for (int i = arr.Length - 1; i > index; i--)
            {
                arr[i] = arr[i - 1];
            }
            count++;
            arr[index] = item;
        }

        public bool IsExist(T item) => IndexOf(item) == -1;
        

        public T Remove(T item)
        {
            int index = IndexOf(item);
            if (index == -1)
            {
                Console.WriteLine("is Not Found");
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
            if (index == -1)
            {
                Console.WriteLine("is Not Found");
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
    }
}
