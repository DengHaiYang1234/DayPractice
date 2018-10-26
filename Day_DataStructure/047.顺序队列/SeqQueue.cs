using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class SeqQueue : ISeqQueue
    {
        int[] arr;
        int addIndex;
        int reduceIndex;
        int count;
        int[] min;



        public SeqQueue(int len)
        {
            arr = new int[len];
            min = new int[len];
            addIndex = 0;
            count = 0;
            reduceIndex = 0;
        }

        public SeqQueue() : this(3)
        {

        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public void Clear()
        {
            addIndex = reduceIndex = count = 0;
        }

        public int Dequeue()
        {
            int value = arr[reduceIndex];
            reduceIndex++;
            if (reduceIndex >= count)
            {
                reduceIndex = 0;
            }
            count--;
            return value;
        }

        public void Enqueue(int item)
        {
            if (addIndex >= arr.Length)
            {
                addIndex = 0;
                count = arr.Length;
            }

            arr[addIndex] = item;
            addIndex++;

            if(count != arr.Length)
            {
                count++;
            }
            
        }

        public bool IsEmpty() => count == 0;
        
        public int Peek() => arr[reduceIndex];



    }
}
