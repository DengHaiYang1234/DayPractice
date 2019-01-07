using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class StringDS
    {
        private char[] arr;

        public StringDS(int len)
        {
            arr = new char[len];
        }

        public StringDS(char[] str)
        {
            arr = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                arr[i] = str[i];
            }
        }

        public StringDS(string str)
        {
            arr = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                arr[i] = str[i];
            }
        }

        public override string ToString()
        {
            return new string(arr);
        }

        public int Length
        {
            get { return arr.Length; }
            
        }
        

        public char this[int index]
        {
            get { return arr[index]; }
        }

        public int Compare(StringDS str)
        {
            int len = this.Length > str.Length ? str.Length : this.Length;

            int index = -1;

            for (int i = 0; i < len; i++)
            {
                if (this[i] != str[i])
                {
                    index = i;
                }
            }

            if (index == -1)
            {
                if (this.Length == str.Length)
                {
                    return 0;
                }
                else
                {
                    if (this.Length > str.Length)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            else
            {
                if (this[index] > str[index])
                {
                    return 1;
                }
                else
                    return -1;
            }
        }

        public StringDS Substring(int index)
        {
            int len = this.Length;
            char[] newArr = new char[len - index];

            for (int i = index; i < len; i++)
            {
                newArr[i - index] = this[i];
            }

            return new StringDS(newArr);
        }

        public StringDS Substring(int index,int count)
        {
            int len = this.Length;
            char[] newArr = new char[count];

            if (index + count >= len)
            {
                Console.WriteLine("越界");
                return null;
            }
            else
            {
                for (int i = index; i < index + count; i++)
                {
                    newArr[i - index] = this[i];
                }
                return new StringDS(newArr);
            }
        }

        public int IndexOf(StringDS str)
        {
            #region 普通匹配
            //int i = 0;
            //int j = 0;

            //while (i < this.Length && j < str.Length)
            //{
            //    if (this[i++] == str[j])
            //    {
            //        j++;
            //    }
            //    else
            //    {
            //        i = i - j;
            //        j = 0;
            //    }
            //}

            //if (j == str.Length)
            //{
            //    return i - j;
            //}

            //return -1;
            #endregion

            #region KMP模式匹配

            int i = 0;
            int j = -1;

            int[] next = GetNext(str);

            while (i < this.Length && j < str.Length)
            {
                if (j == -1 || this[i] == str[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    j = next[j];
                }
            }

            if (j == str.Length)
            {
                return i - j;
            }

            #endregion

            return -1;
        }

        public int[] GetNext(StringDS str)
        {
            int i = 0;
            int j = -1;
            int[] next = new int[str.Length];
            next[0] = -1;

            while (i < str.Length)
            {
                if (j == -1 || str[i] == str[j])
                {
                    next[i++] = j++;
                    if (i < str.Length) //检测是否有重复字符串 aaaaaaaaaaaaaaabbb  .
                    {
                        if (this[i] != str[j])
                        {
                            next[i] = j;
                        }
                        else
                        {
                            next[i] = next[j]; //大话数据结构 P143
                        }
                    }
                }
                else
                {
                    j = next[j];
                }
            }

            return next;
        }
    }
}
