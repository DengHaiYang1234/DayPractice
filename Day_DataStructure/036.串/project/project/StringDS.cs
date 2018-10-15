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


        public StringDS Remove(int startIndex)
        {
            char[] newChar = new char[startIndex];
            for(int i = 0; i < startIndex;i++)
            {
                newChar[i] = arr[i];
            }

            arr = newChar;
            return new StringDS(arr);
        }

        public StringDS Remove(int startIndex, int Count)
        {
            if (startIndex + Count > arr.Length)
            {
                Console.WriteLine("错误");
                return null;
            }
            char[] newChar1 = new char[arr.Length - Count];

            for (int i = 0; i < startIndex; i++)
            {
                newChar1[i] = arr[i];
            }

            int index = startIndex + Count;
            for (int i = index; i < arr.Length;i++)
            {
                newChar1[i - index + startIndex] = arr[i];
            }

            arr = newChar1;

            return new StringDS(arr);
        }

        public StringDS SubString(int startIndex)
        {
            char[] newChar = new char[Count - startIndex];
            for(int i = startIndex;i < Count;i++)
            {
                newChar[i - startIndex] = arr[i];
            }

            arr = newChar;
            return new StringDS(arr);
        }

        public StringDS SubString(int startIndex, int count)
        {
            char[] newChar = new char[count];

            for (int i = startIndex; i < startIndex + count; i++)
            {
                newChar[i - startIndex] = arr[i];
            }

            arr = newChar;
            return new StringDS(arr);
        }

            
        public StringDS[] Split(char sign)
        {
            int haveSignNum = 0;
            int[] indexList = new int[haveSignNum];
            for (int i = 0; i< Count;i++)
            {
                if(arr[i].Equals(sign))
                {
                    haveSignNum += 1;

                    int[] newList = new int[haveSignNum];

                    for (int j = 0; j < indexList.Length; j++)
                    {
                        newList[j] = indexList[j];
                    }

                    newList[haveSignNum - 1] = i;

                    indexList = newList;
                }
            }

            StringDS[] splitList = new StringDS[indexList.Length + 1];
            int splitIndex = 0;

            if (indexList.Length > 0)
            {
                //第一个位置的索引
                int len_firstIndex = indexList[0];
                SetData(splitList, 0, len_firstIndex, len_firstIndex,splitIndex);

                //中间部位
                if (indexList.Length > 1)
                {
                    for(int i = 1; i < indexList.Length; i++)
                    {
                        int len_midIndex = indexList[i];
                        int splitCount = len_midIndex - indexList[splitIndex];
                        int count = splitCount - 1;
                        int startIndex = indexList[splitIndex] + 1;
                        splitIndex++;
                        SetData(splitList, startIndex, len_midIndex, count, splitIndex);
                    }
                }

                //最后的位置
                int len_endIndex = indexList[indexList.Length - 1];
                int endCount = Count - len_endIndex;
                int _startIndex = len_endIndex + 1;
                splitIndex++;
                SetData(splitList, _startIndex, Count, endCount, splitIndex);
            }


            return splitList;

        }


        public void SetData(StringDS[] sts,int startIndex,int endIndex,int newCharCount,int splitIndex)
        {
            char[] newChar = new char[newCharCount];

            for (int i = startIndex; i < endIndex; i++)
            {
                newChar[i - startIndex] = arr[i];
            }

            sts[splitIndex] = new StringDS(newChar);
        }

    }

    
}
