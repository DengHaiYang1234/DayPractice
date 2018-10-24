using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class ListDS<T> : IListDs<T>
    {
        T[] arr;
        int count;

        public ListDS(int len)
        {
            arr = new T[len];
            count = 0;
        }

        public ListDS() : this(2)
        {
            
        }

        public T this[int index]
        {
            get
            {
                return arr[index];
            }
        }


        public int Length
        {
            get
            {
                return arr.Length;
            }
        }

        public void Add(T item)
        {
            if(count >= Length)
            {
                T[] newArr = new T[count + 1];
                for (int i = 0; i < Length; i++)
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

        public int GetLength() => Length;
        
        public int IndexOf(T item)
        {
            int index = -1;
            for(int i = 0; i< Length;++i)
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
            if(count >= Length)
            {
                T[] newArr = new T[count + 1];
                for (int i = 0; i < Length; i++)
                    newArr[i] = arr[i];
                arr = newArr;
            }

            for(int i = Length - 1;i > index;i--)
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
            T value = default(T);
            if (index == -1)
            {
                Console.WriteLine("不存在该元素");
            }
            else if(Length <= 0)
            {
                Console.WriteLine("超出索引");
            }
            else
            {
                value = arr[index];
                for(int i = index;i < Length - 1;i++)
                {
                    arr[i] = arr[i + 1];
                }
                count--;
            }
            return value;
        }

        public T RemoveAt(int index)
        {
            T value = default(T);
            if (Length <= 0 || index < 0 || index >= Length)
            {
                Console.WriteLine("超出索引");
            }
            else
            {
                value = arr[index];
                for (int i = index; i < Length - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                count--;
            }
            return value;
        }
    }
}
