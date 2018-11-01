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

        public StringDS Remove(int stratIndex)
        {
            if (arr.Length == 0)
            {
                Console.WriteLine("Remove   数组为空");
                return null;
            }

            char[] newChar = new char[stratIndex];

            for (int i = 0; i < stratIndex; i++)
            {
                newChar[i] = arr[i];
            }

            arr = newChar;

            return new StringDS(arr);
        }

        public StringDS Remove(int startIndex,int count)
        {
            int len = Count - count;

            if (startIndex > len)
            {
                Console.WriteLine("越界了");
                return null;
            }

            char[] newChar = new char[len];

            int newIndex = 0;

            for (int i = 0; i < startIndex; i++)
            {
                newChar[i] = arr[i];
                newIndex = i + 1;
            }


            int index = startIndex + count;



            for (int j = index; j < Count; j++)
            {
                newChar[newIndex + (j - index)] = arr[j];
            }

            arr = newChar;

            return new StringDS(arr);
        }

        public StringDS Substring(int startIndex)
        {
            if (arr.Length == 0)
            {
                Console.WriteLine("为空");
                return null;
            }

            int len = Count - startIndex;

            char[] newChar = new char[len];

            for (int i = startIndex; i < Count; i++)
            {
                newChar[i - startIndex] = arr[i];
            }

            arr = newChar;

            return new StringDS(arr);
        }

        public StringDS Substring(int startIndex, int count)
        {
            int len = count;

            char[] newChar = new char[len];

            int maxIndex = startIndex + count;

            for (int i = startIndex; i < maxIndex; i++)
                newChar[i - startIndex] = arr[i];

            arr = newChar;
            return new StringDS(arr);
        }

        public StringDS[] Split(char sign)
        {
            if (arr.Length == 0)
            {
                Console.WriteLine("Split  数组为空");
                return null;
            }

            int signNum = 0;

            int[] signIndex = new int[signNum];

            for (int i = 0; i < Count; i++)
            {
                if (arr[i].Equals(sign))
                {
                    signNum += 1;

                    if (signIndex.Length == 0)
                    {
                        int[] newArr = new int[signNum];
                        newArr[newArr.Length - 1] = i;
                        signIndex = newArr;
                    }
                    else
                    {
                        int[] newArr_ = new int[signNum];

                        for (int j = 0; j < signIndex.Length; j++)
                            newArr_[j] = signIndex[j];

                        newArr_[newArr_.Length - 1] = i;
                        signIndex = newArr_;
                    }
                }
            }

            if (signNum == 0)
            {
                Console.WriteLine("没有找到该符号");
                return null;
            }

            StringDS[] newStrings = new StringDS[signNum + 1];

            char[] newChar_1 = new char[signIndex[1]];
            
            int firstIndex = signIndex[1];
            int endIndex = signIndex[signIndex.Length - 1] + 1;
            char[] newChar_end = new char[Count - endIndex];

            int index = 0;
            for (int i = 0; i < signIndex[index]; i++)
            {
                newChar_1[i] = arr[i];
            }

            newStrings[index] = new StringDS(newChar_1);


            for (int i = 1; i < signIndex.Length; i++)
            {
                int mid_index = signIndex[i];
                int mid_pre_index = signIndex[i - 1];
                int len = mid_index - mid_pre_index - 1;
                char[] newChar_mid = new char[len];

                int mid_start_index = mid_pre_index + 1;

                for (int j = mid_start_index; j < mid_index; j++)
                {
                    newChar_mid[j - mid_start_index] = arr[j];
                }
                index += 1;

                newStrings[index] = new StringDS(newChar_mid);

            }


            for (int i = endIndex; i < Count; i++)
            {
                newChar_end[i - endIndex] = arr[i];
            }

            newStrings[newStrings.Length - 1] = new StringDS(newChar_end);


            return newStrings;
        }
    }
}
