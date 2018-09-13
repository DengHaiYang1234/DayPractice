﻿using System;
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
			arr = new char[str.Length];
			for(int i = 0;i < str.Length;i++)
			{
				arr[i] = str[i];
			}
		}

		public StringDS(char[] cr)
		{
			arr = new char[cr.Length];
			for(int i = 0;i < cr.Length;i++)
			{
				arr[i] = cr[i];
			}
		}

		public StringDS(int size)
		{
			arr = new char[size];
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


		/// <summary>
		/// 小于0.strA < strB  -1
		/// 大于0.strA > strB  0
		/// 等于0.strA = strB  1
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		//public static int Compare(StringDS strA,StringDS strB)
		//{
		//	int result = 0;
		//	int size = strA.Count > strB.Count ? strB.Count : strA.Count;
		//	bool isEqual = true;
		//	for(int i = 0; i < size;i++)
		//	{
		//		if (strA[i] != strB[i])
		//		{
		//			if(strA[i] > strB[i])
		//			{
		//				result = 1;
		//			}
		//			else
		//			{
		//				result = -1;
		//			}
		//			isEqual = false;
		//			break;
		//		}
		//	}

		//	if (isEqual)
		//	{
		//		if (strA.Count == strB.Count)
		//		{
		//			result = 0;
		//		}
		//		else
		//		{
		//			if(strA.Count > strB.Count)
		//			{
		//				result = 1;
		//			}
		//			else
		//			{
		//				result = 1;
		//			}
		//		}
		//	}

		//	return result;
		//}

		public static int Compare(StringDS strA, StringDS strB)
		{
			int index = -1;
			int result = 0;
			int size = strA.Count > strB.Count ? strB.Count : strA.Count;
			for(int i = 0; i < size;i++)
			{
				if(strA[i] != strB[i])
				{
					index = i;
					break;
				}
			}

			if(index == -1)
			{
				if(strA.Count == strB.Count)
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
			else
			{
				if(strA[index] > strB[index])
				{
					result = 1;
				}
				else
				{
					result = -1;
				}
			}
			return result;
		}


		public static bool Equals(StringDS strA, StringDS strB) => (Compare(strA, strB) == 1);

		public int IndexOf(StringDS str)
		{
			int thisLen = this.Count;
			int strLen = str.Count;

			int index = -1;

			if (strLen > thisLen)
				return index;

			
			for (int i = 0; i < thisLen;i++)
			{
				bool isEquals = true;
				if (this[i] == str[0])
				{
					if(thisLen - i >= strLen)
					{
						for (int j = 0; j < strLen;j++)
						{
							if (this[i + j] != str[j])
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
			int count = this.Count;
			char[] newStr = new char[startIndex];

			for(int i = 0; i < startIndex;i++)
			{
				newStr[i] = this[i];
			}

			return new StringDS(newStr);
		}

		public StringDS Remove(int startIndex,int count)
		{
			int size = this.Count - count;
			char[] newStr = new char[size];
			
			for(int i = 0;i < startIndex;i++)
			{
				newStr[i] = this[i];
			}

			int endIndex = startIndex + count;

			for (int i = endIndex; i < this.Count;i++)
			{
				newStr[i - count] = arr[i];
			}

			return new StringDS(newStr);

		}

		public StringDS[] Split(char separator)
		{
			int size = 0;
			int[] ts = new int[0];
			for (int i = 0; i < this.Count; i++)
			{
				if (this[i].Equals(separator))
				{
					size += 1;

					int[] _ts = new int[size];

					if (size == 1)
					{
						_ts[0] = i;

					}
					else
					{
						for (int index = 0; index < ts.Length; i++)
						{
							_ts[index] = ts[index];
						}
						_ts[_ts.Length - 1] = i;
					}

					ts = _ts;
				}
			}
			Console.WriteLine("ts.Length  ts.Length:" + ts.Length);

			StringDS[] ss = new StringDS[ts.Length + 1];

			for (int i = 0; i < ts.Length; i++)
			{
				int leftIndex;
				int rightIndex;
				int newSize;
				if(i == 0)
				{
					leftIndex = 0;
					rightIndex = ts[i];
					newSize = ts[i];
				}
				else
				{
					leftIndex = ts[i - 1] + 1;
					rightIndex = ts[i];
					newSize = rightIndex - leftIndex - 1;
				}

				char[] newChar = new char[newSize];
				for (int j = leftIndex; j < rightIndex; j++)
				{
					newChar[j - leftIndex] = arr[j];
				}

				ss[i] = new StringDS(newChar);
			}

			char[] newChar1 = new char[this.Count - ts[ts.Length - 1]];
			int startIndex = ts[ts.Length - 1] + 1;
			for (int i = startIndex; i < this.Count;i++)
			{
				newChar1[i - startIndex] = this[i];
			}

			ss[ss.Length - 1] = new StringDS(newChar1);

			return ss;
		}


		public override string ToString()
		{
			return new string(arr);
		}

	}
}
