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
        public Node PreNode { get; set; }
        public Node NextNode { get; set; }

        public Node(int value, Node pre, Node next)
        {
            Data = value;
            PreNode = pre;
            NextNode = next;
        }
    }
}
