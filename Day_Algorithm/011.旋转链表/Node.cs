using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }

        public Node(int value)
        {
            Data = value;
            Next = null;
        }

        public void Append(Node node)
        {
            Next = node;
        }
    }
}
