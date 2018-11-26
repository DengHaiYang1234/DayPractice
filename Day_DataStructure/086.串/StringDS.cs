using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
        int IndexOf(StringDS str);
        int[] GetIndex(StringDS str);
        StringDS Remove(int startIndex);
        StringDS Remove(int startIndex, int count);
        StringDS[] Split(char separator);
        StringDS Substring(int startIndex);
        StringDS Substring(int startIndex, int count);
 * 
 * 
 */
namespace project
{
    public class StringDS
    {
        private char[] charArr;

        public StringDS(string str)
        {
            charArr = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
                charArr[i] = str[i];
        }

        public StringDS(char[] str)
        {
            charArr = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
                charArr[i] = str[i];
        }

        public StringDS(int len)
        {
            charArr = new char[len];
        }

        public int length
        {
            get { return charArr.Length; }
        }

        public char this[int index]
        {
            get { return charArr[index]; }
            set { charArr[index] = value; }
        }

        public override string ToString()
        {
            return new string(charArr);
        }

        public static implicit operator StringDS(string v)
        {
            return new StringDS(v);
        }

        #region static Func

        public static int Compare(StringDS str1,StringDS str2)
        {
            int len = str1.length > str2.length ? str2.length : str1.length;
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
                if (str1.length == str2.length)
                {
                    return 0;
                }
                else
                {
                    if (str1.length > str2.length)
                        return 1;
                    else
                        return -1;
                }
            }
            else
            {
                if (str1[index] > str2[index])
                    return 1;
                else
                    return -1;
            }

        }

        #endregion
        public int IndexOf(StringDS str)
        {
            #region 1.普通模式匹配

            //int i = 0;
            //int j = 0;


            //while (i < this.length && j < str.length)
            //{
            //    if (this[i] == str[j])
            //    {
            //        i++;
            //        j++;
            //    }
            //    else
            //    {
            //        i = i - j + 1;
            //        j = 0;
            //    }
            //}
                
            //if (j == str.length)
            //{
            //    return i - j;
            //}


            //return -1;


            #endregion

            #region 2.普通模式匹配（stringSub方法）

            //int i = 0;
            //int count = str.length;

            //while (i < this.length)
            //{
            //    StringDS newStr = SubString(i, count);

            //    if (Compare(newStr, str) != 0)
            //    {
            //        i++;
            //    }
            //    else
            //    {
            //        return i;
            //    }
            //}

            //return -1;

            #endregion

            #region 3.KMP模式匹配

            int i = 0;
            int j = 0;

            int[] next = GetNext(str);

            while (i < this.length && j < str.length)
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

            if (j == str.length)
                return i - j;
            else
                return -1;

            #endregion
        }

        public int[] GetNext(StringDS str)
        {
            int[] next = new int[str.length];
            int i = 0;
            int j = -1; //下一移动位置
            next[0] = -1;

            while (i < str.length)
            {
                if (j == -1 || str[i] == str[j])
                {
                    next[i++] = j++;
                }
                else
                    j = next[j];
            }

            return next;
        }

        public StringDS SubString(int startIndex)
        {
            int len = this.length - startIndex;
            char[] newChar = new char[len];
            for (int i = startIndex; i < this.length; i++)
            {
                newChar[i - startIndex] = this[i];
            }

            return new StringDS(newChar);
        }

        public StringDS SubString(int startIndex, int count)
        {
            char[] newChar = new char[count];
            int endIndex = startIndex + count;

            if (endIndex < this.length)
            {
                for (int i = startIndex; i < endIndex; i++)
                {
                    newChar[i - startIndex] = this[i];
                }
            }
            else
            {
                return new StringDS("");
            }

            return new StringDS(newChar);
        }

        public StringDS Remove(int startIndex)
        {
            char[] newChar = new char[startIndex];

            for (int i = 0; i < startIndex; i++)
            {
                newChar[i] = this[i];
            }
            return new StringDS(newChar);
        }

        public StringDS Remove(int startIndex,int count)
        {
            int len = this.length - count;
            char[] newChar = new char[len];

            for (int i = 0; i < startIndex; i++)
            {
                newChar[i] = this[i];
            }

            int sIndex = startIndex + count;

            for (int i = sIndex; i < this.length; i++)
            {
                newChar[i - count] = this[i];
            }

            return new StringDS(newChar);
        }

        public StringDS[] Split(char character)
        {
            List<int> _list = new List<int>();

            bool isHave = false;

            for (int i = 0; i < this.length; i++)
            {
                if (this[i].Equals(character))
                {
                    _list.Add(i);
                    isHave = true;
                }
            }

            if (!isHave)
            {
                Console.WriteLine("null");
                return null;
            }

            StringDS[] SDS = new StringDS[_list.Count + 1];
            int currentIndex = 0;
            //1
            StringDS SDS_Front = SubString(currentIndex, _list[currentIndex]);
            SDS[currentIndex] = SDS_Front;


            for (int i = 1; i < _list.Count; i++)
            {
                currentIndex += 1;
                StringDS SDS_Mid = SubString(_list[i - 1] + 1, _list[i] - _list[i - 1] - 1);
                SDS[currentIndex] = SDS_Mid;
            }

            StringDS SDS_Rear = SubString(_list[currentIndex] + 1);
            SDS[currentIndex + 1] = SDS_Rear;


            return SDS;
        }


        
    }
}
