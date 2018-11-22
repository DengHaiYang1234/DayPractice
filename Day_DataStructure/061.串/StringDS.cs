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
            //int index = -1;
            //int i = 0;
            //int strLen = str.count;
            ////可截取索引位置
            //int subIndex = count - strLen + 1;

            #region No.1
            //while (i < subIndex)
            //{
            //    StringDS _str = Substring(i, strLen);

            //    if (Compare(str, _str) != 0)
            //        ++i;
            //    else
            //    {
            //        index = i;
            //        break;
            //    }  
            //}
            #endregion
            #region No.2
            //while (i < count)
            //{
            //    while (i < count && this[i] != str[0])
            //        i++;

            //    int isEquals = -1;
            //    if (this[i] != str[0])
            //    {
            //        StringDS _str = Substring(i, strLen);

            //        isEquals = Compare(str, _str);
            //    }

            //    if (isEquals == 0)
            //    {
            //        index = i;
            //        break;
            //    }
            //    else
            //    {
            //        i++;
            //    }
            //}
            #endregion
            #region No.3
            //int strLen = str.count;
            //int index = -1;
            //for (int i = 0; i < count; i++)
            //{
            //    if (this[i] == str[0])
            //    {
            //        int surplusLen = count - i;
            //        if (surplusLen >= strLen)
            //        {
            //            bool isEqual = true;
            //            for (int j = 0; j < strLen; j++)
            //            {
            //                if (this[j + i] != str[j])
            //                {
            //                    isEqual = false;
            //                    i = i - j + 1; //需要回溯
            //                    continue;
            //                }
            //            }
            //            if (isEqual)
            //            {
            //                index = i;
            //                break;
            //            }
            //        }
            //        else
            //        {
            //            return -1;
            //        }
            //    }
            //}
            #endregion

            //return index;
            #region No.4 标准KMP

            //主字符串索引
            int i = 0;
            //匹配字符串索引
            int j = 0;
            //匹配字符串next数组
            int[] next = GetIndex(str);

            while (i < this.count && j < str.count)
            {
                //不断进行匹配。不匹配就 使用匹配串的下一位置
                if (j == -1 || this[i] == str[j])
                {
                    i++;
                    j++; //全部匹配成功。返回
                }
                else
                {
                    //若发现匹配串与主串 不匹配。匹配串就移动至一下位置
                    j = next[j];
                }
            }

            //匹配成功
            if (j == str.count)
            {
                return i - j;
            }
            else
                return -1;
            #endregion
        }

        public int[] GetIndex(StringDS str)
        {
            int[] next = new int[str.count]; //保存匹配字符串中的每个字符的下一移动位置的集合

            next[0] = -1;
            //字符索引
            int j = 0;

            //j对应的下一移动的位置
            int k = -1;

            while (j < str.count - 1)
            {
                //若匹配那么就直接移动到上一次出现该元素的位置.  若不匹配那么就返回初始位置
                if (k == -1 || str[j] == str[k])  
                {
                    next[++j] = ++k;
                }
                else
                    k = next[k]; //不匹配的时候。下一移动的位置
            }

            return next;
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
            int len = count;
            if (len < 0)
                len = 0;
            char[] newChar = new char[len];
            int length = startIndex + count;
            for (int i = startIndex; i < length; i++)
                newChar[i - startIndex] = arr[i];
            return new StringDS(newChar);
        }
    }
}
