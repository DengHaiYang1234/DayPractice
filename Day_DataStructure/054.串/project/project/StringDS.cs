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


        public StringDS(char[] arr_)
        {
            arr = new char[arr_.Length];

            for (int i = 0; i < arr_.Length; i++)
            {
                arr[i] = arr_[i];
            }

        }

        public StringDS(string str)
        {
            arr = new char[str.Length];

            for (int i = 0; i < str.Length; i++)
                arr[i] = str[i];
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
            get { return arr.Length; }
        }


        public override string ToString()
        {
            return new string(arr);
        }

        public static int Compare(StringDS str1,StringDS str2)
        {
            int shortLen = str1.Count > str2.Count ? str2.Count : str1.Count;

            int index = -1;

            for (int i = 0; i < shortLen; i++)
            {
                if (str1[i] != str2[i])
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
            {
                if (str1[index] > str2[index])
                    return 1;
                else
                    return -1;
            }
            else
            {
                if (str1.Count == str2.Count)
                    return 0;
                else
                {
                    if (str1.Count > str2.Count)
                        return 1;
                    else
                        return -1;
                }
            }

        }

        public static bool Equals(StringDS str1, StringDS str2) => Compare(str1, str2) == 1;

        //没有返回-1.有的话返回1
        public int IndexOf(StringDS str)
        {
            if (Count == 0)
            {
                Console.WriteLine("数组为空");
                return -1;
            }

            int baseValue = str[0];
            int baseIndex = -1;
            for (int i = 0; i < Count; i++)
            {
                if (arr[i] == baseValue)
                {
                    baseIndex = i;
                    int surplusNum = Count - baseIndex;
                    if (surplusNum < str.Count)
                        return -1;
                    else
                    {
                        bool isEuqls = true;
                        for (int j = baseIndex; j < baseIndex + str.Count; j++)
                        {
                            if (arr[j] != str[j - baseIndex])
                            {
                                isEuqls = false;
                                break;
                            }
                        }

                        if (isEuqls)
                        {
                            break;
                        }
                        else
                        {
                            baseIndex = -1;
                            continue;
                        }
                            
                    }
                }
            }
            return baseIndex;
        }
    }
}
