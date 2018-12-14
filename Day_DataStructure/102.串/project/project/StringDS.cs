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

        public static int Compare(StringDS s1, StringDS s2)
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

        public StringDS Substring(int index, int count)
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

        public int LastIndexOf(StringDS s)
        {
            return IndexOfByKMP(s, true);
        }

        public int IndexOfByKMP(StringDS s, bool isLast)
        {
            List<int> list = new List<int>();
            int i = 0;
            int j = 0;
            int[] next = GetNext(s);

            while (i < Length && j < s.Length)
            {
                if (j == -1 || this[i] == s[j])
                {
                    i++;
                    j++;
                    if (isLast)
                    {
                        if (j == s.Length)
                        {
                            list.Add(i - j);
                            j = 0;
                            continue;
                        }
                    }
                }
                else
                {
                    j = next[j];
                }
            }

            if (list.Count > 0)
            {
                return list[list.Count - 1];
            }

            return -1;
        }

        public List<int> AllIndexOf(StringDS s)
        {
            List<int> list = new List<int>();
            int i = 0;
            int j = 0;
            int[] next = GetNext(s);

            while (i < Length && j < s.Length)
            {
                if (j == -1 || this[i] == s[j])
                {
                    i++;
                    j++;
                    if (j == s.Length)
                    {
                        list.Add(i - j);
                        j = 0;
                        continue;
                    }
                }
                else
                {
                    j = next[j];
                }
            }

            return list;
        }

        public StringDS Reversal(StringDS str)
        {
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < str.Length; i++)
                stack.Push(str[i]);

            char[] newChar = new char[str.Length];

            for (int i = 0; i < str.Length; i++)
                newChar[i] = stack.Pop();

            return new StringDS(newChar);
        }

        public StringDS[] Split(char separator)
        {
            List<int> separatorIndexList = new List<int>();
            for (int i = 0; i < Length; i++)
            {
                if (this[i].Equals(separator))
                {
                    separatorIndexList.Add(i);
                }
            }

            if (separatorIndexList.Count <= 0)
            {
                Console.WriteLine(" Split is Called , But Dont Find separator");
                return null;
            }

            StringDS[] sds = new StringDS[separatorIndexList.Count + 1];

            int sdsIndex = 0;
            int frontIndex = separatorIndexList[sdsIndex];
            sds[sdsIndex] = Substring(0, frontIndex);

            sdsIndex++;

            for (int i = 1; i < separatorIndexList.Count; i++)
            {
                int startIndex = separatorIndexList[i - 1] + 1;
                int count = separatorIndexList[i] - startIndex;
                sds[sdsIndex] = Substring(startIndex, count);
                sdsIndex++;
            }

            int rearIndex = separatorIndexList[separatorIndexList.Count - 1] + 1;
            sds[sdsIndex] = Substring(rearIndex);

            return sds;
        }

        public StringDS Replace(char oldChar, char newChar)
        {
            char[] newChars = arr;
            for (int i = 0; i < Length; i++)
            {
                if (newChars[i].Equals(oldChar))
                {
                    newChars[i] = newChar;
                }
            }
            return new StringDS(newChars);
        }

        public StringDS Remove(int index)
        {
            char[] newChar = new char[index];
            for (int i = 0; i < index; i++)
            {
                newChar[i] = this[i];
            }

            return new StringDS(newChar);
        }

        public StringDS Remove(int index,int count)
        {
            int len = Length - count;
            char[] newChar = new char[len];
            StringDS sds_1 = Substring(0, index - 1);
            StringDS sds_2 = Substring(index + count);
            return Concat(sds_1, sds_2);
        }

        public StringDS Concat(StringDS s1,StringDS s2)
        {
            char[] newChar = new char[s1.Length + s2.Length];
            for (int i = 0; i < s1.Length + s2.Length; i++)
            {
                if (i < s1.Length)
                {
                    newChar[i] = s1[i];
                }
                else if(i >= s1.Length && i < s2.Length)
                {
                    newChar[i] = s2[i - s1.Length];
                }
            }

            return new StringDS(newChar);
        }
    }
}
