using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class SeqList<T> : ISeqList<T>
    {

        T[] data;
        int count;

        public SeqList(int len)
        {
            data = new T[len];
            count = 0;
        }

        public SeqList() : this(1)
        {

        }

        public T this[int index]
        {
            get
            {
                return data[index];
            }
        }

        public int Length
        {
            get
            {
                return count;
            }
        }

        public void Add(T item)
        {
            if(count >= data.Length)
            {
                T[] newItem = new T[count * 2];
                for(int i = 0;i < data.Length;i++)
                {
                    newItem[i] = data[i];
                }
                newItem[count] = item;
                data = newItem;
                count++;
            }
            else
            {
                data[count] = item;
                count++;
            }
        }

        public void Clear() => count = 0;


        public int GetLength() => count;
       

        public int IndexOf(T item)
        {
            int index = -1;
            for(int i = 0; i< data.Length;i++)
            {
                if (data[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public void Insert(int index, T item)
        {
            if(index > count || index < 0)
            {
                Console.WriteLine("超界限");
                return;
            }

            if(count >= data.Length)
            {
                T[] newItem = new T[count * 2];
                for(int i = 0; i< data.Length;i++)
                {
                    newItem[i] = data[i];
                }
                data = newItem;
            }

            for(int i = count - 1; i >= index;i--)
            {
                data[i + 1] = data[i];
            }
            data[index] = item;
            count++;
        }

        public bool IsExist(T item) => IndexOf(item) == -1;
        

        public T Remove(T item)
        {
            T value = default(T);
            if(count == 0)
            {
                Console.WriteLine("数组为空");
                return value;
            }

            int index = IndexOf(item);
            if(index == -1)
            {
                Console.WriteLine("没有该元素");
                return value;
            }
            value = data[index];
            for(int i = index;i < count - 1;i++)
            {
                data[i] = data[i + 1];
            }
            count--;
            return value;
        }

        public T RemoveAt(int index)
        {
            T value = default(T);
            if (index > count || index < 0)
            {
                Console.WriteLine("数组超界限");
                return value;
            }
            value = data[index];
            for (int i = index; i < count - 1; i++)
            {
                data[i] = data[i + 1];
            }
            count--;
            return value;
        }
    }
}
