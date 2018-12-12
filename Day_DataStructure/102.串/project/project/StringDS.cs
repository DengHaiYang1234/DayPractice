﻿using System;
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

        public StringDS() : this(10)
        {
            
        }

        public StringDS(string str)
        {
            arr = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                arr[i] = str[i];
            }
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

        public override string ToString()
        {
            return new string(arr);
        }

        public static int Compare(StringDS s1,StringDS s2)
        {
            int len = s1.Length > s2.Length ? s2.Length : s1.Length;
            int index = -1;

            for (int i = 0; i < len; i++)
            {
                if (s1[i] != s2[i])
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                if (s1.Length == s2.Length)
                {
                    return 0;
                }
                else
                {
                    if (s1.Length > s2.Length)
                    {
                        return 1;
                    }
                    else
                        return -1;
                }
            }
            else
            {
                if (s1[index] > s2[index])
                {
                    return 1;
                }
                else
                    return -1;
            }
        }

        public StringDS Substring(int index)
        {
            char[] newChar = new char[Length - index];

            for (int i = index; i < Length; i++)
            {
                newChar[i - index] = arr[i];
            }

            return new StringDS(newChar);
        }

        public StringDS Substring(int index,int count)
        {
            char[] newChar = new char[count];

            int endIndex = index + count;

            for (int i = index; i < endIndex; i++)
            {
                newChar[i - index] = arr[i];
            }

            return new StringDS(newChar);
        }

        public int IndexOfBySubString(StringDS s)
        {
            if (Compare(this, s) == 0)
            {
                return 0;
            }
            else
            {
                int i = 0;
                while (i <= Length - s.Length)
                {
                    StringDS sd = Substring(i, s.Length);
                    if (Compare(sd, s) == 0)
                    {
                        return i;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
            return -1;
        }

        public int IndexOfByIndex(StringDS s)
        {
            int i = 0;
            int j = 0;
            while (i < Length && j < s.Length)
            {
                if (s[j] == this[i])
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

            if (j == s.Length)
            {
                return i - j;
            }

            return -1;
        }

        public int IndexOfByKMP(StringDS s)
        {
            int i = 0;
            int j = 0;

            int[] next = GetNext(s);

            while (i < Length && j < s.Length)
            {
                if (j == -1 || this[i] == s[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    j = next[j];
                }
            }

            if (j == s.Length)
            {
                return i - j;
            }

            return -1;
        }

        /// <summary>
        /// 获取匹配串的Next
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int[] GetNext(StringDS s)
        {
            int i = 0;
            int j = -1;
            int[] next = new int[Length];
            next[0] = -1;
            while (i < Length - 1 && j < s.Length - 1)
            {
                if (j == -1 || this[i] == s[j])
                {
                    i++;
                    j++;
                    if (this[i] != s[j])
                    {
                        next[i] = j;
                    }
                    else
                    {
                        next[i] = next[j];
                    }
                }
                else
                {
                    j = next[j]; //j值回溯
                }
            }

            return next;
        }
    }
}
