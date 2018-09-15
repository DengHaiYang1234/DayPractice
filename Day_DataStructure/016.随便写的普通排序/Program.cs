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
			int[] arr = { 1, 8,5,2,5,6,9,8,7,1,2,5,86,5};

			Sort(arr);

			for(int i = 0; i< arr.Length;i++)
			{
				Console.WriteLine(arr[i]);
			}
		}

		static void Sort(int[] arr)
		{
			for(int i = 0; i < arr.Length;i++)
			{
				for(int j = i; j < arr.Length;j++)
				{
					if(arr[i] > arr[j])
					{
						var temp = arr[i];
						arr[i] = arr[j];
						arr[j] = temp;
					}
				}
			}
		}

	}
}
