using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] arr = { 1, 8, 5,2,5,6,9,8,7,1,2,5,86,5};
			Sort(0, arr.Length - 1, arr);


			for(int i = 0;i < arr.Length;i++)
			{
				Console.WriteLine(arr[i]);
			}

		}


		static void Sort(int leftIndex, int rightIndex, int[] arr)
		{
			if(leftIndex >= rightIndex)
			{
				return; 
			}

			int midIndex = SortAndGetMidIndex(leftIndex, rightIndex, arr);

			Sort(leftIndex, midIndex - 1, arr);

			Sort(midIndex + 1, rightIndex, arr);
		}


		static int SortAndGetMidIndex(int leftIndex,int rightIndex,int[] arr)
		{
			int baseValue = arr[leftIndex];

			while(leftIndex < rightIndex)
			{

				//从右至左  找小
				while (leftIndex < rightIndex && baseValue < arr[rightIndex])
					rightIndex--;

				arr[leftIndex] = arr[rightIndex];
				//从左至右  找大
				while (leftIndex < rightIndex && baseValue >= arr[leftIndex])
					leftIndex++;
				arr[rightIndex] = arr[leftIndex]; 
			}

			arr[leftIndex] = baseValue;
			return leftIndex;
		}
	}
}
