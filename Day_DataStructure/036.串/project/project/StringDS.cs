using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class StringDS
    {
        char[] arr;

        public StringDS(string str)
        {
            int len = str.Length;
            arr = new char[len];
            for (int i = 0; i < len; i++)
            {
                arr[i] = str[i];
            }
        }

        public StringDS(char[] str)
        {
            int len = str.Length;
            arr = new char[len];
            for (int i = 0; i < len; i++)
            {
                arr[i] = str[i];
            }
        }

        public StringDS(int len)
        {
            arr = new char[len];
        }

        public char this[int index]
        {
            get
            {
                return arr[index];
            }
        }

        public int Length() => arr.Length;

        public int Count
        {
            get
            {
                return arr.Length;
            }
        }

        public static int Compare(StringDS strA, StringDS strB)
        {
            int len = strA.Length() > strB.Length() ? strB.Length() : strA.Length();

            int index = -1;
            int result = 0;
            for (int i = 0; i < len; i++)
            {
                if (strA[i] != strB[i])
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
            {
                if (strA[index] > strB[index])
                {
                    result = 1;
                }
                else
                {
                    result = -1;
                }
            }
            else
            {
                if (strA.Length() == strB.Length())
                {
                    result = 0;
                }
                else
                {
                    if (strA.Count > strB.Count)
                    {
                        result = 1;
                    }
                    else
                    {
                        result = -1;
                    }
                }
            }
            return result;
        }

        public static bool Equals(StringDS strA, StringDS strB) => Compare(strA, strB) == 1;

        //与字符串str是否有相匹配的。若有并返回第一个所有，若没有返回-1
        public int IndexOf(StringDS str)
        {
            int index = -1;

            for (int i = 0; i < Count; i++) //自身字符串
            {
                if (arr[i] == str[0])//两个字符串第一个匹配
                {
                    int surplusLen = Count - i - 1; //自身字符串剩余长度
                    if (surplusLen >= str.Count) //保证自身字符串剩余长度与匹配的字符串长度大或等于
                    {
                        bool isEquals = true;
                        for (int j = 0;j < str.Count;j++)
                        {
                            if(arr[i + j] != str[j])
                            {
                                isEquals = false;
                                break;
                            }
                        }

                        if(isEquals)
                        {
                            index = i;
                            break;
                        }

                    }
                }

            }
            return index;
        }

        public override string ToString()
        {
            return new string(arr);
        }
    }

    
}
