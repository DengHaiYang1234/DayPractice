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
        private int count;

        public SeqList(int len)
        {
            arr = new T[len];
            count = 0;
        }

        public SeqList() : this(3)
        {
            
        }

        public T this[int index]
        {
            get { return arr[index]; }
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
                for (int i = 0; i < arr.Length; i++)
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
            if (index < 0 || index > count)
            {
                return;
            }

            if (count >= arr.Length)
            {
                T[] newArr = new T[count*2];
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

        public bool IsExist(T item)
        {
            return IndexOf(item) == -1;
        }

        public T Remove(T item)
        {
            int index = IndexOf(item);
            T value = arr[index];
            if (index == -1)
            {
                return default(T);
            }
            else
            {
                for (int i = index; i < count - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                count--;
            }

            return value;
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index > count)
            {
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
