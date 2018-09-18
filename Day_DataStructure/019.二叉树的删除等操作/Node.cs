using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Node<T>
    {
        public int Data;
        public Node<T> Left;
        public Node<T> Right;

        public void Display()
        {
            Console.WriteLine(Data);
        }

        public Node(int x)
        {
            Data = x;
        }
    }
}
