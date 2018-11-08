using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
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

        public SeqList() : this(2)
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
                for (int i = 0; i < count; i++)
                    newArr[i] = arr[i];

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
            if (count <= 0)
            {
                Console.WriteLine("数组为空");
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    if (arr[i].Equals(item))
                    {
                        index = i;
                        break;
                    }
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
                    arr[i] = newArr[i];

                arr = newArr;
            }

            for (int i = count - 1; i >= index; i--)
            {
                arr[i + 1] = arr[i];
            }

            arr[index] = item;
            count++;
        }

        public bool IsExist(T item) => IndexOf(item) == -1;

        public T Remove(T item)
        {
            int index = IndexOf(item);
            T value = default(T);
            if (index == -1 || index < 0 || index > count)
            {
                Console.WriteLine("没有找到该元素");
            }
            else
            {
                value = arr[index];
                for (int i = index; i < count; i++)
                {
                    arr[i] = arr[i + 1];
                }
            }
            count--;
            return value;
        }

        public T RemoveAt(int index)
        {
            T value = default(T);
            if (index < 0 || index > count)
            {
                Console.WriteLine("索引越界");
            }
            else
            {
                value = arr[index];
                for (int i = index; i < count; i++)
                    arr[i] = arr[i + 1];
            }
            count--;
            return value;
        }
    }
}
