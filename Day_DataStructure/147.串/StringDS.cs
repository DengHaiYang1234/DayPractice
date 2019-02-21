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

        public StringDS(string str)
        {
            arr = new char[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                arr[i] = str[i];
            }
        }

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

        public int Length
        {
            get { return arr.Length; }
        }

        public char this[int index]
        {
            get { return arr[index]; }
        }

        public static int Compare(StringDS str1,StringDS str2)
        {
            int len = str1.Length > str2.Length ? str2.Length : str1.Length;

            int index = -1;

            for (int i = 0; i < len; i++)
            {
                if (str1[i] != str2[i])
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                if (str1.Length == str2.Length)
                {
                    return 0;
                }
                else
                {
                    if (str1.Length > str2.Length)
                    {
                        return 1;
                    }
                    else
                        return -1;
                }
            }
            else
            {
                if (str1[index] > str2[index])
                {
                    return 1;
                }
                else
                    return -1;
            }
        }

        public int IndexOf(StringDS str)
        {
            int i = 0;
            int j = 0;

            while (i < this.Length && j < str.Length)
            {
                if (this[i] == str[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    i = i - j + 1;
                    j = 0;
                }
            }

            if (j == str.Length)
            {
                return i - j;
            }
            else
            {
                return -1;
            }
        }

        public int IndexOfByKMP(StringDS str)
        {
            int i = 0;
            int j = 0;
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
            else
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
                }
                else
                {
                    j = next[j];
                }
            }

            return next;
        }

        public override string ToString()
        {
            return new string(arr);
        }
    }
}
