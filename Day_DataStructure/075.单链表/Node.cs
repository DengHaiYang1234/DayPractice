using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { set; get; }

        public Node(T item)
        {
            Data = item;
            Next = null;
        }
    }
}
