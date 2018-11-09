using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
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
                arr[i] = str[i];
        }

        public StringDS(string str)
        {
            arr = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
                arr[i] = str[i];
        }

        public override string ToString()
        {
            return new string(arr);
        }

        public char this[int index]
        {
            get { return arr[index]; }
        }

        public int count
        {
            get { return arr.Length; }
        }
        
        public static int Compare(StringDS str1,StringDS str2)
        {
            //相对长度较短的str
            int len = str1.count > str2.count ? str2.count : str1.count;

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
                if (str1.count == str2.count)
                {
                    return 0;
                }
                else
                {
                    if (str1.count > str2.count)
                        return 1;
                    else
                        return -1;
                }
            }

            if (str1[index] > str2[index])
                return 1;
            else
                return -1;

        }

        public int IndexOf(StringDS str)
        {
            int strLen = str.count;
            int index = -1;
            for (int i = 0; i < count; i++)
            {
                if (this[i] == str[0])
                {
                    int surplusLen = count - i;
                    if (surplusLen >= strLen)
                    {
                        bool isEqual = true;
                        for (int j = 0; j < strLen; j++)
                        {
                            if (this[j + i] != str[j])
                            {
                                isEqual = false;
                                continue;
                            }
                        }
                        if (isEqual)
                        {
                            index = i;
                            break;
                        }
                    }
                    else
                    {
                        return -1;
                    }
                }
            }

            return index;
        }

        public StringDS Remove(int startIndex)
        {
            char[] newChar = new char[startIndex];

            for (int i = 0; i < startIndex; i++)
                newChar[i] = arr[i];

            return new StringDS(newChar);
        }

        public StringDS Remove(int startIndex, int count)
        {
            int len = this.count - count;
            char[] newChar = new char[len];

            for (int i = 0; i < startIndex; i++)
                newChar[i] = arr[i];

            int rIndex = startIndex + count;
            for (int i = rIndex; i < this.count; i++)
            {
                newChar[i - count] = arr[i];
            }

            return new StringDS(newChar);

        }

        public StringDS[] Split(char separator)
        {
            List<int> separatorList = new List<int>();

            bool isHave = false;

            for (int i = 0; i < count; i++)
            {
                if (this[i].Equals(separator))
                {
                    isHave = true;
                    separatorList.Add(i);
                }
            }

            if (!isHave)
            {
                Console.WriteLine("不存在该符号");
                return null;
            }

            StringDS[] SDS = new StringDS[separatorList.Count + 1];

            //头部分
            int SDS_Index = 0;

            int index_First = separatorList[0];
            char[] newChar_First = new char[index_First];
            for (int i = 0; i < index_First; i++)
                newChar_First[i] = this[i];

            SDS[SDS_Index] = new StringDS(newChar_First) ;

            //中间部分
            for (int i = 1; i < separatorList.Count; i++)
            {
                int index_Current = separatorList[i];
                int index_Pre = separatorList[i - 1] + 1;
                int len = index_Current - index_Pre;
                char[] newChar_Current = new char[len];

                for (int j = index_Pre; j < index_Current; j++)
                {
                    newChar_Current[j - index_Pre] = arr[j];
                }
                SDS_Index++;
                SDS[SDS_Index] = new StringDS(newChar_Current);
            }

            //尾部
            int index_Tail = separatorList[separatorList.Count - 1] + 1;
            int len_Tail = count - index_Tail;
            char[] newChar_Tail = new char[len_Tail];

            for (int i = index_Tail; i < count; i++)
            {
                newChar_Tail[i - index_Tail] = this[i];
            }
            SDS_Index++;
            SDS[SDS_Index] = new StringDS(newChar_Tail);
            return SDS;
        }

        public StringDS Substring(int startIndex)
        {
            int len = this.count - startIndex;
            char[] newChar = new char[len];
            for (int i = startIndex; i < count; i++)
            {
                newChar[i - startIndex] = arr[i];
            }

            return new StringDS(newChar);
        }

        public StringDS Substring(int startIndex, int count)
        {
            int len = startIndex + count;
            if (len < 0)
                len = 0;
            char[] newChar = new char[len];
            int lenght = startIndex + count;
            for (int i = startIndex; i < lenght; i++)
                newChar[i - startIndex] = arr[i];
            return new StringDS(newChar);
        }
    }
}
